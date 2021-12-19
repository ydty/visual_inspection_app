using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace VisualInspectionApp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

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
                //TODO: 推論処理を書く
                var assetsRelativePath = @"..\..\..\assets";
                string assetsPath = GetAbsolutePath(assetsRelativePath);
                var modelFilePath = Path.Combine(assetsPath, "Model", "segmentation_model.onnx");
                var imagesFolder = Path.Combine(assetsPath, "images");
                var outputFolder = Path.Combine(assetsPath, "images", "output");

                // Initialize MLContext
                MLContext mlContext = new MLContext();

                IEnumerable<ImageNetData> images = ImageNetData.ReadFromFile(imagesFolder);
                IDataView imageDataView = mlContext.Data.LoadFromEnumerable(images);

                // Create IDataView from empty list to obtain input data schema
                var data = mlContext.Data.LoadFromEnumerable(new List<ImageNetData>());

                // Define scoring pipeline
                var pipeline = mlContext.Transforms.LoadImages(outputColumnName: "image", imageFolder: "", inputColumnName: nameof(ImageNetData.ImagePath))
                                .Append(mlContext.Transforms.ApplyOnnxModel(modelFile: modelFilePath, outputColumnNames: new[] { SegmentaionModelSettings.ModelOutput }, inputColumnNames: new[] { SegmentaionModelSettings.ModelInput }));

                //var pipeline = mlContext.Transforms.ApplyOnnxModel(modelFile: modelLocation, outputColumnNames: new[] { SegmentaionModelSettings.ModelOutput }, inputColumnNames: new[] { SegmentaionModelSettings.ModelInput });

                // Fit scoring pipeline
                var model = pipeline.Fit(data);

                IDataView scoredData = model.Transform(imageDataView);

                var from2 = new Form2();
                from2.Show();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
    }

    public class ImageNetData
    {
        [LoadColumn(0)]
        public string ImagePath;

        [LoadColumn(1)]
        public string Label;

        public static IEnumerable<ImageNetData> ReadFromFile(string imageFolder)
        {
            return Directory
                .GetFiles(imageFolder)
                .Select(filePath => new ImageNetData { ImagePath = filePath, Label = Path.GetFileName(filePath) });
        }
    }

    public struct SegmentaionModelSettings
    {
        // for checking Tiny yolo2 Model input and  output  parameter names,
        //you can use tools like Netron, 
        // which is installed by Visual Studio AI Tools

        // input tensor name
        public const string ModelInput = "input_1";

        // output tensor name
        public const string ModelOutput = "sigmoid";
    }
}