namespace AQC.Manifestly.Core.Client
{
    using System;
    using AQC.Manifestly.Core.Client.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RestSharp;
    using Serilog;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Logging;
    using AQC.Manifestly.Core.Client.Contracts;
    using RestSharp.Serializers.NewtonsoftJson;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using AQC.Manifestly.Core.Client.Data.Responses;

    public class ManifestlyClient : IManifestlyClient, IDisposable
    {
        private readonly ILogger<ManifestlyClient> _logger;
        private readonly ManifestlyConfiguration _config;
        private readonly RestClient _client;

        public ManifestlyClient(ILogger<ManifestlyClient> logger, IOptions<ManifestlyConfiguration> config)
        {
            _logger = logger;

            _config = config.Value;

            var options = new RestClientOptions { BaseUrl = new Uri(_config.BaseUrl) };

            _client = new RestClient(options)
                .AddDefaultParameter("api_key", _config.ServiceApiKey);

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
                Formatting = Formatting.None
            };

            _client.UseNewtonsoftJson(settings);
        }

        public async Task<ListAllActiveWorkflowsResponse> ListAllActiveWorkflowsByDepartmentIdAsync(int departmentId)
        {
            var request = new RestRequest("checklists")
              .AddParameter("department_id", departmentId);

            var response = await _client.ExecuteGetAsync<ListAllActiveWorkflowsResponse>(request);

            if (!response.IsSuccessful)
            {
                _logger.LogError(response.ErrorMessage, response);
            }

            return response.Data!;
        }

        public async Task<ListAllUsersResponse> ListAllUsersByDepartmentIdAsync(int departmentId)
        {
            var request = new RestRequest("users")
              .AddParameter("department_id", departmentId);

            var response = await _client.ExecuteGetAsync<ListAllUsersResponse>(request);

            if (!response.IsSuccessful)
            {
                _logger.LogError(response.ErrorMessage, response);
            }

            return response.Data!;
        }

        public async Task<ListAllRunsResponse> ListAllRunsByWorkflowIdAsync(int workflowId, int page)
        {
            var request = new RestRequest("runs")
              .AddParameter("checklist_id", workflowId)
              .AddParameter("page", page);

            var response = await _client.ExecuteGetAsync<ListAllRunsResponse>(request);

            if (!response.IsSuccessful)
            {
                _logger.LogError(response.ErrorMessage, response);
            }

            return response.Data!;
        }

        public async Task<ListAllRunStepsResponse> ListAllRunStepsByRunIdAsync(int runId)
        {
            var request = new RestRequest("runs/{run_id}/run_steps")
              .AddUrlSegment("run_id", runId);

            var response = await _client.ExecuteGetAsync<ListAllRunStepsResponse>(request);

            if (!response.IsSuccessful)
            {
                _logger.LogError(response.ErrorMessage, response);
            }

            return response.Data!;
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
