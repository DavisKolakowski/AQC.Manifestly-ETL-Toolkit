namespace AQC.Manifestly.Core.Client.Data.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public record RunObject(
        int Id,
        string? Title,
        int ChecklistId,
        string DetailedTitle,
        string? Description,
        double PercentCompleted,
        string Summary,
        DateTime? StartedAt,
        DateTime? CompletedAt,
        DateTime? LateAt,
        string State,
        string ArchiveUrl,
        IReadOnlyList<UserObject> Users
        );
}
