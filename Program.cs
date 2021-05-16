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
using TrouvailleFrontend.Shared.Classes.Test;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Classes.API;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

namespace TrouvailleFrontend {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazorise(options => {
                options.ChangeTextOnKeyPress = true;
            })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons();

            // builder.Services.AddBlazorise().AddBootstrapProviders().AddFontAwesomeIcons();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient<ILocalStorage, LocalStorage>();
            builder.Services.AddTransient<IHttpRequest, HttpRequest>();

            builder.Services.AddScoped<IProductIterator, ProductsIteratorTest>();
            builder.Services.AddTransient<IProductsRetriever, ProductsRetrieverTest>();
            builder.Services.AddTransient<ILogin, LoginTest>();
            builder.Services.AddTransient<IOrder, OrderTest>();

            // builder.Services.AddScoped<IProductIterator, ProductsIterator>();
            // builder.Services.AddTransient<IProductsRetriever, ProductsRetrieverAPI>();
            // builder.Services.AddTransient<ILogin, LoginAPI>();
            // builder.Services.AddTransient<IOrder, OrderAPI>();


            await builder.Build().RunAsync();
        }
    }
}
