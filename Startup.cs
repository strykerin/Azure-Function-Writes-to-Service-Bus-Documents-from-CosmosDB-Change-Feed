using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(ServiceBusOutputFunction.Startup))]
namespace ServiceBusOutputFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Inject IConfiguration
            // https://burhaantargett.tech/2019-07-16-azure-functions-di-and-configuration/
            var localRoot = Environment.GetEnvironmentVariable("AzureWebJobsScriptRoot");
            var azureRoot = $"{Environment.GetEnvironmentVariable("HOME")}/site/wwwroot";
            var actualRoot = localRoot ?? azureRoot;
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(actualRoot)
                .AddEnvironmentVariables()
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = configBuilder.Build();
            builder.Services.AddSingleton(configuration);
        }
    }
}
