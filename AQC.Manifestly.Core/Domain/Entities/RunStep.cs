namespace AQC.Manifestly.Core.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RunStep
    {
        public int Id { get; set; }

        public int RunId { get; set; }

        public Run Run { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

        public string Title { get; set; }

        public bool Skipped { get; set; }

        public DateTime? CompletedAt { get; set; }

        public DateTime? LateAt { get; set; }

        public List<RunStepComment>? Comments { get; set; }
    }
}
