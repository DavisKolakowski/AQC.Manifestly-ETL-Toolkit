namespace AQC.Manifestly.Core.Client.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WorkflowData
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public int DepartmentId { get; set; }
    }
}
