using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInspectionApp.DataStructures
{
    public class ConcreteImageData
    {
        [LoadColumn(0)]
        public string ImagePath;

        [LoadColumn(1)]
        public string Label;

        public static IEnumerable<ConcreteImageData> ReadFromFile(string imageFolder)
        {
            return Directory
                .GetFiles(imageFolder)
                .Select(filePath => new ConcreteImageData { ImagePath = filePath, Label = Path.GetFileName(filePath) });
        }
    }
}
