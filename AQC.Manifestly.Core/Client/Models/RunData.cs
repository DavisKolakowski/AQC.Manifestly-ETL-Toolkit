namespace AQC.Manifestly.Core.Client.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RunData
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string DetailedTitle { get; set; }

        public string? Description { get; set; }

        public double PercentCompleted { get; set; }

        public string Summary { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public DateTime? LateAt { get; set; }

        public string State { get; set; }

        public string ArchiveUrl { get; set; }

        public int WorkflowId { get; set; }
    }
}
