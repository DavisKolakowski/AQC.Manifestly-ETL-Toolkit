namespace AQC.Manifestly.Utility
{
    using AQC.Manifestly.Core.Application.Configuration;
    using AQC.Manifestly.Core.Application.Services;
    using AQC.Manifestly.Core.Domain.Data;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    using Serilog;
    using VaultSharp.V1.AuthMethods.Token;
    using VaultSharp.V1.AuthMethods;
    using VaultSharp.V1.Commons;
    using VaultSharp;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateBootstrapLogger();

            var dbConnection = configuration.GetConnectionString("SqlDatabase");

            var serviceProvider = new ServiceCollection()
                .ConfigureAQCManifestlyCoreServices(configuration, dbConnection)
                .BuildServiceProvider();

            await AQCManifestlyDatabaseService.RunAsync(serviceProvider);

            Log.Information("Database task finished at: {time}", DateTimeOffset.Now);
        }
    }
}