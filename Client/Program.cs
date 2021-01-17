using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test_Blazor_MLNet.Shared;

namespace Test_Blazor_MLNet.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            // Removed for Blazor pre-rendering
            //builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Add Lucene Index service (load Lucene Index from zip file and expose Directory Reader)
            builder.Services.AddSingleton<LuceneIndexService>(LuceneIndexService.Instance);

            await builder.Build().RunAsync();
        }
    }
}
