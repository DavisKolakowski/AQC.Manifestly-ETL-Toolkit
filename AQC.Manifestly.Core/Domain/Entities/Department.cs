namespace AQC.Manifestly.Core.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Workflow>? Workflows { get; set; }
    }
}
