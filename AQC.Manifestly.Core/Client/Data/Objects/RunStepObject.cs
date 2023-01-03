namespace AQC.Manifestly.Core.Client.Data.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public record RunStepObject(
        int Id,
        string Title,
        bool Skipped,
        DateTime? CompletedAt,
        DateTime? LateAt,
        IReadOnlyList<CommentObject>? Comments,
        int RunId,
        int? UserId,
        UserObject? User
        );
}
