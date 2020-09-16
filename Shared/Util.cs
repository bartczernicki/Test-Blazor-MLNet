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
        public static Stream GetModel()
        {
            var assembly = typeof(Test_Blazor_MLNet.Shared.WeatherForecast).Assembly;
            string[] names = assembly.GetManifestResourceNames();
            Stream resource = assembly.GetManifestResourceStream("Test-Blazor-MLNet.Shared.Models.InductedToHallOfFame-LightGbm.mlnet");

            return resource;
        }
    }
}
