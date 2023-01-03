namespace AQC.Manifestly.Core.Client.Data.Responses
{
    using AQC.Manifestly.Core.Client.Data.Objects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public record ListAllActiveWorkflowsResponse(
        IReadOnlyList<WorkflowObject> Checklists
        );
}
