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

            //��ʉ����̉摜�\�����ɉ摜������ݒ�
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
        /// �Z�O�����e�[�V�������f���̐��_
        /// </summary>
        private void SegmentationModelPredict()
        {
            //�Ƃ肠�������؂̂���assets/images�̉摜��ΏۂƂ���

            var assetsPath = @"../../../assets";
            var modelFilePath = Path.Combine(assetsPath, "Model", "segmentation_model.onnx");

            //���؂̂���assets/Images�̃t�H���_����f�[�^���擾
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
            var result = model.Predict(imageDataView).ToList();
        }
    }
}