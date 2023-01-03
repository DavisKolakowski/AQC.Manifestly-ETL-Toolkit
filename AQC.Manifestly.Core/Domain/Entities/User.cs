namespace AQC.Manifestly.Core.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }       

        public string SimpleDisplayName { get; set; }

        public string Username { get; set; }

        public List<RunStep>? RunSteps { get; set; }
    }
}
