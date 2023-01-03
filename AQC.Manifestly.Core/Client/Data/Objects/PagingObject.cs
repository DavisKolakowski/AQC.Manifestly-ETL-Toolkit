namespace AQC.Manifestly.Core.Client.Data.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public record PagingObject(
        int CurrentPage,
        int? NextPage,
        int? PreviousPage,
        int TotalPages,
        int TotalEntries,
        int PerPage
        );
}
