
using Blazored.Toast;

using BlazorProducts.Client.HttpInterceptor;
using BlazorProducts.Client.HttpRepository;
using Entities.ConfigurationModels;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.Web;



using Toolbelt.Blazor.Extensions.DependencyInjection;

using BlazorProducts.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiConfiguration = new ApiConfiguration();
builder.Configuration.Bind("ApiConfiguration", apiConfiguration);
builder.Services.AddHttpClient("MuthurajApi", (sp, cl) =>
    {

        cl.BaseAddress = new Uri(apiConfiguration.BaseAddress + "/api/");
        cl.EnableIntercept(sp);
    });
builder.Services.AddBlazoredToast();
builder.Services.AddScoped(
    sp => sp.GetService<IHttpClientFactory>().CreateClient("MuthurajApi"));
builder.Services.AddHttpClientInterceptor();

builder.Services.AddScoped<ICountryHttpRepository, CountryHttpRepository>();

builder.Services.AddScoped<HttpInterceptorService>();



await builder.Build().RunAsync();
