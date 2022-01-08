using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualInspectionApp.DataStructures;

namespace VisualInspectionApp
{
    // segmentationの推論クラス
    // 参考(https://docs.microsoft.com/ja-jp/dotnet/machine-learning/tutorials/object-detection-onnx)
    public class SegmentationModelPredict
    {
        private readonly string imagesFolder;
        private readonly string modelLocation;
        private readonly MLContext mlContext;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SegmentationModelPredict(string imagesFolder, string modelLocation, MLContext mlContext)
        {

            this.imagesFolder = imagesFolder;
            this.modelLocation = modelLocation;
            this.mlContext = mlContext;
        }

        /// <summary>
        /// 画像サイズ設定
        /// </summary>
        public struct ImageNetSettings
        {
            public const int imageHeight = 256;
            public const int imageWidth = 256;
        }

        /// <summary>
        /// モデル入出力の項目名
        /// </summary>
        public struct SegmentationModellSettings
        {
            //netron(https://netron.app/)で変換済みのonnxモデルを確認し、入出力のtensor nameを設定

            // input tensor name
            public const string ModelInput = "input_1";

            // output tensor name
            public const string ModelOutput = "sigmoid";
        }

        /// <summary>
        /// モデルのロード
        /// </summary>
        /// <param name="modelLocation">モデルの場所</param>
        /// <returns></returns>
        private ITransformer LoadModel(string modelLocation)
        {

            Console.WriteLine("Read model");
            Console.WriteLine($"Model location: {modelLocation}");
            Console.WriteLine($"Default parameters: image size=({ImageNetSettings.imageWidth},{ImageNetSettings.imageHeight})");

            // 実際のトレーニングは行わないため空のIDataViewを作成
            var data = mlContext.Data.LoadFromEnumerable(new List<ConcreteImageData>());

            // パイプラインの作成
            var pipeline = mlContext.Transforms.LoadImages(outputColumnName: "input_1", imageFolder: "", inputColumnName: nameof(ConcreteImageData.ImagePath))
                            .Append(mlContext.Transforms.ResizeImages(outputColumnName: "input_1", imageWidth: ImageNetSettings.imageWidth, imageHeight: ImageNetSettings.imageHeight, inputColumnName: "input_1"))
                            .Append(mlContext.Transforms.ExtractPixels(outputColumnName: "input_1", interleavePixelColors: true))
                            .Append(mlContext.Transforms.ApplyOnnxModel(modelFile: modelLocation, outputColumnNames: new[] { SegmentationModellSettings.ModelOutput }, inputColumnNames: new[] { SegmentationModellSettings.ModelInput }));

            // モデルのインスタンス化
            var model = pipeline.Fit(data);

            return model;
        }

        private IEnumerable<float[]> PredictDataUsingModel(IDataView testData, ITransformer model)
        {
            Console.WriteLine($"Images location: {imagesFolder}");
            Console.WriteLine("");
            Console.WriteLine("=====Identify the objects in the images=====");
            Console.WriteLine("");

            IDataView predictionData = model.Transform(testData);

            IEnumerable<float[]> result = predictionData.GetColumn<float[]>(SegmentationModellSettings.ModelOutput);

            return result;
        }

        public IEnumerable<float[]> Predict(IDataView data)
        {
            var model = LoadModel(modelLocation);

            return PredictDataUsingModel(data, model);
        }
    }
}
