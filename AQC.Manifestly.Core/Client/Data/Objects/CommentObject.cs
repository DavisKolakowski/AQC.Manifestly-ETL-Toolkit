namespace AQC.Manifestly.Core.Client.Data.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public record CommentObject(
        int Id,
        DateTime CreatedAt,
        string CommentWithLinks,
        DateTime? UpdatedAt,
        string Identifier,
        int UserId
        );
}
