namespace AQC.Manifestly.Core.Application.Configuration
{
    using AQC.Manifestly.Core.Client.Contracts;
    using AQC.Manifestly.Core.Client;
    using AQC.Manifestly.Core.Client.Configuration;
    using AQC.Manifestly.Core.Domain.Contracts.Extensions;
    using AQC.Manifestly.Core.Domain.Contracts.Repository;
    using AQC.Manifestly.Core.Domain.Data;
    using AQC.Manifestly.Core.Domain.Entities;
    using AQC.Manifestly.Core.Domain.Extensions;
    using AQC.Manifestly.Core.Domain.Profiles;
    using AQC.Manifestly.Core.Domain.Repository;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Serilog;
    using Microsoft.Extensions.Logging.Configuration;
    using Microsoft.Extensions.Logging;

    public static class ApplicationServicesConfiguration
    {
        public static IServiceCollection ConfigureAQCManifestlyCoreServices(this IServiceCollection services, IConfiguration configuration, string? dbConnection)
        {
            services.AddLogging(builder =>
                    builder.AddConfiguration(configuration).AddSerilog());

            services.AddOptions();

            services.Configure<ManifestlyConfiguration>(options =>
                configuration.GetSection(ManifestlyConfiguration.Manifestly).Bind(options));

            services.AddScoped<IManifestlyClient, ManifestlyClient>();

            services.AddDbContext<AQCManifestlyDbContext>(opt => opt
                .UseSqlServer(dbConnection, options =>
                    options.MigrationsAssembly("AQC.Manifestly.Core")
                        .MigrationsHistoryTable("__EFMigrationsHistory", "AQC.Manifestly")));

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IManifestlyClientDataExtensions, ManifestlyClientDataExtensions>();

            services.AddScoped<IAQCManifestlyDataMappingExtensions, AQCManifestlyDataMappingExtensions>();

            services.AddScoped<IRepositoryCollection, RepositoryCollection>();

            return services;
        }
    }
}
