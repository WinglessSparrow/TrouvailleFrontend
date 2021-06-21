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
            builder.Services.AddSingleton<IErrorHandler, ErrorHandler>();

            builder.Services.AddScoped<IProductIterator, ProductsIteratorTest>();
            builder.Services.AddTransient<IProductsRetriever, ProductsRetrieverTest>();
            builder.Services.AddTransient<ILogin, LoginTest>();
            builder.Services.AddTransient<IOrderer, OrdererTest>();
            builder.Services.AddTransient<IRegister, RegisterTest>();
            builder.Services.AddTransient<IUserDataGetter, UserDataGetterTest>();
            builder.Services.AddTransient<IUserDataChanger, UserDataChangerTest>();
            builder.Services.AddTransient<IOrderRetriever, OrderRetrieverTest>();
            builder.Services.AddTransient<IPasswordChanger, PasswordChangerTest>();

            // builder.Services.AddTransient<IPasswordChanger, PasswordChangerTest>();
            // builder.Services.AddScoped<IProductIterator, ProductsIterator>();
            // builder.Services.AddTransient<IProductsRetriever, ProductsRetrieverAPI>();
            // builder.Services.AddTransient<ILogin, LoginAPI>();
            // builder.Services.AddTransient<IOrder, OrderAPI>();
            // builder.Services.AddTransient<IRegister, RegisterAPI>();
            // builder.Services.AddTransient<IOrderRetriever, OrderRetrieverAPI>();

            //TODO -CLASSES
            // builder.Services.AddTransient<IUserDataGetter, RegisterAPI>();
            // builder.Services.AddTransient<IUserDataChanger, RegisterAPI>();

            await builder.Build().RunAsync();
        }
    }
}
