using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.ML;
using VisualInspectionApp.DataStructures;
using OpenCvSharp;
using NLog;

namespace VisualInspectionApp
{
    public partial class Form1 : Form
    {

        private readonly MLContext _mlContext;
        private readonly Logger _logger;

        /// <summary>
        /// 設定ファイルで指定した出力先のフォルダ
        /// </summary>
        private string _outputDirectory;

        private string _outputDirRaw;
        private string _outputDirGood;
        private string _outputDirBad;
        private string _outputDirPredict;
        private string _outputDirOverlay;

        private double _sigmoidThreshold;
        private double _pixcelThreshold;


        public Form1(MLContext mlContext, Logger logger)
        {
            InitializeComponent();

            _mlContext = mlContext;
            _logger = logger;

            Init();

        }

        //初期処理
        private void Init()
        {

            //カウントを0にする
            lblImageCountData.Text = "0";

            //appsetting.jsonから設定の読み出し
            var cfb = new ConfigurationBuilder();
            cfb.SetBasePath(Directory.GetCurrentDirectory());
            cfb.AddJsonFile("appsettings.json", true, true);
            var configuration = cfb.Build();

            var section = configuration.GetSection("Settings");
            _outputDirectory = section["OutputDirectoryPath"];
            _sigmoidThreshold = Double.Parse(section["SigmoidThreshold"]);
            _pixcelThreshold = Double.Parse(section["PixelThreshold"]);

        }

        private void listBoxImageFile_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listBoxImageFile_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string item in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                listBoxImageFile.Items.Add(item);
            }

            //画面下部の画像表示数に画像枚数を設定
            lblImageCountData.Text = listBoxImageFile.Items.Count.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //入力チェック
                if (!InputValueValidation())
                {
                    //メッセージボックスを表示する
                    MessageBox.Show("ロット番号と画像を指定してください。",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    return;
                }

                //フォルダを作成
                this.CreateDataFolder();

                //predict
                this.SegmentationModelPredict();

                //this.ReconstructModelPredict();

                var from2 = new Form2(txtLotNo.Text, Path.Combine(_outputDirectory, txtLotNo.Text), _outputDirGood,_outputDirOverlay);
                from2.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns></returns>
        private Boolean InputValueValidation()
        {
            if (txtLotNo.Text.Length == 0)
            {
                return false;
            }

            if (listBoxImageFile.Items.Count == 0)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// フォルダを作成する
        /// </summary>
        private void CreateDataFolder()
        {
            //出力フォルダ+ロットNOを結合したPathを作成し、フォルダを作成する
            var outputDirSettings = _outputDirectory;
            _outputDirRaw = Path.Combine(outputDirSettings, txtLotNo.Text, "raw");
            _outputDirGood = Path.Combine(outputDirSettings, txtLotNo.Text, "good");
            _outputDirBad = Path.Combine(outputDirSettings, txtLotNo.Text, "bad");
            _outputDirPredict = Path.Combine(outputDirSettings, txtLotNo.Text, "predict");
            _outputDirOverlay = Path.Combine(outputDirSettings, txtLotNo.Text, "overlay");

            ExecCreateFolder(_outputDirRaw);
            ExecCreateFolder(_outputDirGood);
            ExecCreateFolder(_outputDirBad);
            ExecCreateFolder(_outputDirPredict);
            ExecCreateFolder(_outputDirOverlay);

            //ファイルをコピーする
            foreach (string image in listBoxImageFile.Items) {

                File.Copy(image, Path.Combine(_outputDirRaw, Path.GetFileName(image)), true);
            }
        }


        /// <summary>
        /// セグメンテーションモデルの推論
        /// </summary>
        private void SegmentationModelPredict()
        {

            var assetsPath = @"../../../assets";
            var modelFilePath = Path.Combine(assetsPath, "Model", "segmentation_model.onnx");


            // Load Data
            IEnumerable<ConcreteImageData> images = ConcreteImageData.ReadFromFile(_outputDirRaw);
            IDataView imageDataView = _mlContext.Data.LoadFromEnumerable(images);

            // Create instance of model
            var model = new SegmentationModelPredict(_outputDirRaw, modelFilePath, _mlContext);

            // predict
            var result = model.Predict(imageDataView).ToList();

            //precit結果を指定の良品・不良品のフォルダへ振り分ける
            this.SortData(result);

        }

        /// <summary>
        /// 再構築モデルの推論
        /// </summary>
        private void ReconstructModelPredict()
        {
            //とりあえず検証のためassets/imagesの画像を対象とする

            var assetsPath = @"../../../assets";
            var modelFilePath = Path.Combine(assetsPath, "Model", "reconstruct_model.onnx");

            //検証のためassets/Imagesのフォルダからデータを取得
            var imagesFolder = Path.Combine(assetsPath, "images");

            // Load Data
            IEnumerable<ConcreteImageData> images = ConcreteImageData.ReadFromFile(imagesFolder);
            IDataView imageDataView = _mlContext.Data.LoadFromEnumerable(images);

            // Create instance of model
            var model = new ReconstructModelPredict(imagesFolder, modelFilePath, _mlContext);

            // predict
            var results = model.Predict(imageDataView).ToList();

        }

        /// <summary>
        /// predict結果をthresholdに基づきデータを振り分け
        /// </summary>
        private void SortData(List<float[]> results)
        {
            string[] names = Directory.GetFiles(_outputDirRaw, "*");

            //fileとpredictの結果をzipにまとめる
            var data = names.Zip(results, (file, result) => new { File = file, Result = result });

            foreach (var item in data)
            {

                //設定したしきい値のピクセルをカウントする(sigmoid)
                if ((double)item.Result.Where(x => x >= _sigmoidThreshold).Count() / (double)65536 >= _pixcelThreshold)
                {
                    //しきい値に基づいて推論結果の画像を作成
                    var predictImagePath = this.PredictImage(item.Result,item.File);

                    this.CreateMergeImage(item.File, predictImagePath);

                    //Badケース
                    File.Copy(item.File, Path.Combine(_outputDirBad, Path.GetFileName(item.File)), true);
                }
                else
                {
                    //Badケース
                    File.Copy(item.File, Path.Combine(_outputDirGood, Path.GetFileName(item.File)), true);

                }
            }
        }

        /// <summary>
        /// 予測結果の画像の配列をしきい値に基づき生成
        /// </summary>
        /// <returns></returns>
        private string PredictImage(float[] result, string fileName)
        {
            var array = new float[256 * 256];

            foreach (var (value, index) in result.Select((value, index) => (value, index)))
            {
                if (value >= _sigmoidThreshold)
                {
                    array[index] = 1;
                }
                else
                {
                    array[index] = 0;
                }

            }

            var writeFile = Path.Combine(_outputDirPredict, Path.GetFileName(fileName));
            var img = new Mat(256, 256, MatType.CV_32F, result);

            //画像を出力
            Cv2.ImWrite(writeFile, 255 * img);

            return writeFile;
        }

        private void CreateMergeImage(string rawImage, string predictImage)
        {
            var img1 = Cv2.ImRead(rawImage);
            var img2 = Cv2.ImRead(predictImage);

            var overlayImage = new Mat();

            Cv2.AddWeighted(img1, 0.7, img2, 0.3, 0, overlayImage);
            //画像を出力
            Cv2.ImWrite(Path.Combine(_outputDirOverlay, Path.GetFileName(rawImage)), overlayImage);

        }

        /// <summary>
        /// フォルダの作成処理
        /// </summary>
        /// <param name="path"></param>
        private void ExecCreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}