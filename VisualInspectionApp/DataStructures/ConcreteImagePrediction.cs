using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInspectionApp.DataStructures
{
    public class ConcreteImagePrediction
    {
        [ColumnName("sigmoid")]
        public float[] PredictedLabels;
    }
}
