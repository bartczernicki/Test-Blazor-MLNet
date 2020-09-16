using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Blazor_MLNet.Shared
{
    public class Util
    {
        public static Stream GetModel(string predictionType, string algorithmName)
        {
            var assembly = typeof(Test_Blazor_MLNet.Shared.Util).Assembly;
            Stream resource = assembly.GetManifestResourceStream($"Test-Blazor-MLNet.Shared.Models.{predictionType}-{algorithmName}.mlnet");

            return resource;
        }

        public static Stream GetBaseballData()
        {
            var assembly = typeof(Test_Blazor_MLNet.Shared.Util).Assembly;

            // var test = assembly.GetManifestResourceNames();
            // taskkill /IM dotnet.exe /F /T 2>nul 1>nul

            Stream resource = assembly.GetManifestResourceStream($"Test-Blazor-MLNet.Shared.Data.MLBBaseballBatters.csv");

            return resource;
        }

        public static PredictionEngine<MLBBaseballBatter, MLBHOFPrediction> GetPredictionEngine(MLContext mlContext, string predictionType, string algorithmName)
        {
            DataViewSchema schema;
            var modelStream = Util.GetModel(predictionType, algorithmName);

            ITransformer _model = mlContext.Model.Load(modelStream, out schema);

            var _predictionEngine = mlContext.Model.CreatePredictionEngine<MLBBaseballBatter, MLBHOFPrediction>(_model);

            return _predictionEngine;
        }
    }
}
