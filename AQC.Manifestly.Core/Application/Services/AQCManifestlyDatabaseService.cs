namespace AQC.Manifestly.Core.Application.Services
{
    using AQC.Manifestly.Core.Domain.Entities;

    using EFCore.BulkExtensions;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Azure;
    using AQC.Manifestly.Core.Domain.Data;
    using AQC.Manifestly.Core.Domain.Contracts.Repository;
    using AQC.Manifestly.Core.Domain.Extensions;
    using AQC.Manifestly.Core.Domain.Contracts.Extensions;
    using Microsoft.EntityFrameworkCore.Storage;
    using Serilog;
    using Serilog.Core;

    public class AQCManifestlyDatabaseService
    {
        public static async Task RunAsync(IServiceProvider serviceProvider)
        {
            Log.Information("Database task started at: {time}", DateTimeOffset.Now);

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                var dataService =
                    scope.ServiceProvider.GetRequiredService<IAQCManifestlyDataMappingExtensions>();

                var repo =
                    scope.ServiceProvider.GetRequiredService<IRepositoryCollection>();

                var departmentsQuery = repo.Departments.FindAll();

                var departments = await dataService.MapDataForDepartmentsAsync(departmentsQuery);

                await repo.Departments.BulkUpsertAsync(departments);               
            }
        }
    }
}
