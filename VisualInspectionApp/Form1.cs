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
        /// �ݒ�t�@�C���Ŏw�肵���o�͐�̃t�H���_
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

        //��������
        private void Init()
        {

            //�J�E���g��0�ɂ���
            lblImageCountData.Text = "0";

            //appsetting.json����ݒ�̓ǂݏo��
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

            //��ʉ����̉摜�\�����ɉ摜������ݒ�
            lblImageCountData.Text = listBoxImageFile.Items.Count.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //���̓`�F�b�N
                if (!InputValueValidation())
                {
                    //���b�Z�[�W�{�b�N�X��\������
                    MessageBox.Show("���b�g�ԍ��Ɖ摜���w�肵�Ă��������B",
                                    "�G���[",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    return;
                }

                //�t�H���_���쐬
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
        /// ���̓`�F�b�N
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
        /// �t�H���_���쐬����
        /// </summary>
        private void CreateDataFolder()
        {
            //�o�̓t�H���_+���b�gNO����������Path���쐬���A�t�H���_���쐬����
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

            //�t�@�C�����R�s�[����
            foreach (string image in listBoxImageFile.Items) {

                File.Copy(image, Path.Combine(_outputDirRaw, Path.GetFileName(image)), true);
            }
        }


        /// <summary>
        /// �Z�O�����e�[�V�������f���̐��_
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

            //precit���ʂ��w��̗Ǖi�E�s�Ǖi�̃t�H���_�֐U�蕪����
            this.SortData(result);

        }

        /// <summary>
        /// �č\�z���f���̐��_
        /// </summary>
        private void ReconstructModelPredict()
        {
            //�Ƃ肠�������؂̂���assets/images�̉摜��ΏۂƂ���

            var assetsPath = @"../../../assets";
            var modelFilePath = Path.Combine(assetsPath, "Model", "reconstruct_model.onnx");

            //���؂̂���assets/Images�̃t�H���_����f�[�^���擾
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
        /// predict���ʂ�threshold�Ɋ�Â��f�[�^��U�蕪��
        /// </summary>
        private void SortData(List<float[]> results)
        {
            string[] names = Directory.GetFiles(_outputDirRaw, "*");

            //file��predict�̌��ʂ�zip�ɂ܂Ƃ߂�
            var data = names.Zip(results, (file, result) => new { File = file, Result = result });

            foreach (var item in data)
            {

                //�ݒ肵���������l�̃s�N�Z�����J�E���g����(sigmoid)
                if ((double)item.Result.Where(x => x >= _sigmoidThreshold).Count() / (double)65536 >= _pixcelThreshold)
                {
                    //�������l�Ɋ�Â��Đ��_���ʂ̉摜���쐬
                    var predictImagePath = this.PredictImage(item.Result,item.File);

                    this.CreateMergeImage(item.File, predictImagePath);

                    //Bad�P�[�X
                    File.Copy(item.File, Path.Combine(_outputDirBad, Path.GetFileName(item.File)), true);
                }
                else
                {
                    //Bad�P�[�X
                    File.Copy(item.File, Path.Combine(_outputDirGood, Path.GetFileName(item.File)), true);

                }
            }
        }

        /// <summary>
        /// �\�����ʂ̉摜�̔z����������l�Ɋ�Â�����
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

            //�摜���o��
            Cv2.ImWrite(writeFile, 255 * img);

            return writeFile;
        }

        private void CreateMergeImage(string rawImage, string predictImage)
        {
            var img1 = Cv2.ImRead(rawImage);
            var img2 = Cv2.ImRead(predictImage);

            var overlayImage = new Mat();

            Cv2.AddWeighted(img1, 0.7, img2, 0.3, 0, overlayImage);
            //�摜���o��
            Cv2.ImWrite(Path.Combine(_outputDirOverlay, Path.GetFileName(rawImage)), overlayImage);

        }

        /// <summary>
        /// �t�H���_�̍쐬����
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