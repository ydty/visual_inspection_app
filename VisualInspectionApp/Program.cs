using Microsoft.ML;

namespace VisualInspectionApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            MLContext mlContext = new MLContext();

            Application.Run(new Form1(mlContext));
        }
    }
}