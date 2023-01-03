namespace AQC.Manifestly.Core.Client.Contracts
{
    using AQC.Manifestly.Core.Client.Data.Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IManifestlyClient
    {
        Task<ListAllActiveWorkflowsResponse> ListAllActiveWorkflowsByDepartmentIdAsync(int departmentId);

        Task<ListAllUsersResponse> ListAllUsersByDepartmentIdAsync(int departmentId);

        Task<ListAllRunsResponse> ListAllRunsByWorkflowIdAsync(int workflowId, int page);

        Task<ListAllRunStepsResponse> ListAllRunStepsByRunIdAsync(int runId);
    }
}
