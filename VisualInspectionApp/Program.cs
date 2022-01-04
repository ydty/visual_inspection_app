using Microsoft.ML;
using NLog;

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

            var logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
            
            var mlContext = new MLContext();
            logger.Debug("init main");

            Application.Run(new Form1(mlContext, logger));
        }
    }
}