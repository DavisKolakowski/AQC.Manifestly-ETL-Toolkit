namespace AQC.Manifestly.Core.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Run
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

        public Workflow Workflow { get; set; }

        public List<RunStep>? RunSteps { get; set; }
    }
}
