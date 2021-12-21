using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.ML;
using VisualInspectionApp.DataStructures;

namespace VisualInspectionApp
{
    public partial class Form1 : Form
    {

        private readonly MLContext _mlContext;

        public Form1(MLContext mlContext)
        {
            InitializeComponent();

            Init();

            _mlContext = mlContext;

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
            string _outputDirectory = section["OutputDirectoryPath"];
        }

        private void listBoxImageFile_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listBoxImageFile_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string item in (string[]) e.Data.GetData(DataFormats.FileDrop))
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
                this.SegmentationModelPredict();

                this.ReconstructModelPredict();

                var from2 = new Form2();
                from2.Show();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// セグメンテーションモデルの推論
        /// </summary>
        private void SegmentationModelPredict()
        {
            //とりあえず検証のためassets/imagesの画像を対象とする

            var assetsPath = @"../../../assets";
            var modelFilePath = Path.Combine(assetsPath, "Model", "segmentation_model.onnx");

            //検証のためassets/Imagesのフォルダからデータを取得
            var imagesFolder = Path.Combine(assetsPath, "images");

            // Load Data
            IEnumerable<ConcreteImageData> images = ConcreteImageData.ReadFromFile(imagesFolder);
            IDataView imageDataView = _mlContext.Data.LoadFromEnumerable(images);

            // Create instance of model
            var model = new SegmentationModelPredict(imagesFolder, modelFilePath, _mlContext);

            // predict
            var result = model.Predict(imageDataView).ToList();
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
            var result = model.Predict(imageDataView).ToList();
        }
    }
}