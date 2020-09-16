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
        public static Stream GetInductedToHallOfFameModel(string algorithmName)
        {
            var assembly = typeof(Test_Blazor_MLNet.Shared.WeatherForecast).Assembly;
            Stream resource = assembly.GetManifestResourceStream($"Test-Blazor-MLNet.Shared.Models.InductedToHallOfFame-{algorithmName}.mlnet");

            return resource;
        }
    }
}
