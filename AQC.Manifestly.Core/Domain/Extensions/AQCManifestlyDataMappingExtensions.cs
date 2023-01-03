namespace AQC.Manifestly.Core.Domain.Extensions
{
    using AQC.Manifestly.Core.Domain.Contracts.Extensions;
    using AQC.Manifestly.Core.Domain.Contracts.Repository;
    using AQC.Manifestly.Core.Domain.Data;
    using AQC.Manifestly.Core.Domain.Entities;

    using AutoMapper;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AQCManifestlyDataMappingExtensions : IAQCManifestlyDataMappingExtensions
    {
        private readonly ILogger<AQCManifestlyDataMappingExtensions> _logger;
        private readonly IServiceProvider _serviceProvider;

        private readonly IMapper _mapper;
        private readonly IManifestlyClientDataExtensions _dataService;

        public AQCManifestlyDataMappingExtensions(ILogger<AQCManifestlyDataMappingExtensions> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;

            var scope = _serviceProvider.CreateScope();

            this._mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
            this._dataService = scope.ServiceProvider.GetRequiredService<IManifestlyClientDataExtensions>();

        }
        public async Task<List<Department>> MapDataForDepartmentsAsync(IEnumerable<Department> departments)
        {
            var departmentsData = new List<Department>();

            foreach (var department in departments)
            {
                var workflowData = await this._dataService.GetWorkflowDataByDepartmentIdAsync(department.Id);

                department.Workflows = this._mapper.Map<List<Workflow>>(workflowData);

                foreach (var workflow in department.Workflows)
                {
                    var runsData = await this._dataService.GetRunDataByWorkflowIdAsync(workflow.Id);

                    workflow.Runs = this._mapper.Map<List<Run>>(runsData);

                    foreach (var run in workflow.Runs)
                    {
                        var runStepsData = await this._dataService.GetRunStepDataByRunIdAsync(run.Id);

                        run.RunSteps = this._mapper.Map<List<RunStep>>(runStepsData);
                    }
                }

                departmentsData.Add(department);
            }

            return departmentsData;
        }
    }
}
