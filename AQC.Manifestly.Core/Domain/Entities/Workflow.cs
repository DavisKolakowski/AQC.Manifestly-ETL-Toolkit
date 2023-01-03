namespace AQC.Manifestly.Core.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Workflow
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public List<Run>? Runs { get; set; }
    }
}
