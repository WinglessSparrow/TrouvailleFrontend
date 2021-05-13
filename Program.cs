using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TrouvailleFrontend.Shared.Classes;

namespace TrouvailleFrontend {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient<ILocalStorage, LocalStorage>();
            builder.Services.AddTransient<IHttpRequest, HttpRequest>();

            builder.Services.AddTransient<IProductIterator, ProductsIterator>();
            builder.Services.AddTransient<IProductsRetriever, ProductsRetriever>();


            await builder.Build().RunAsync();
        }
    }
}
