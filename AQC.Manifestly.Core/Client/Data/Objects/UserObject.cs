namespace AQC.Manifestly.Core.Client.Data.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public record UserObject(
        int Id,
        string Email,
        string Name,
        string SimpleDisplayName,
        string Username
        );
}
