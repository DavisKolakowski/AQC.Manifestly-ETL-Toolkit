namespace AQC.Manifestly.Core.Domain.Contracts.Extensions
{
    using AQC.Manifestly.Core.Client.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IManifestlyClientDataExtensions
    {
        Task<List<WorkflowData>> GetWorkflowDataByDepartmentIdAsync(int departmentId);

        Task<List<UserData>> GetUserDataByDepartmentIdAsync(int departmentId);

        Task<List<RunData>> GetRunDataByWorkflowIdAsync(int workflowId);

        Task<List<RunStepData>> GetRunStepDataByRunIdAsync(int runId);
    }
}
