namespace AQC.Manifestly.Core.Client.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RunStepData
    {
        public int Id { get; set; }

        public int RunId { get; set; }

        public int? UserId { get; set; }

        public UserData? User { get; set; }

        public string Title { get; set; }

        public bool Skipped { get; set; }

        public DateTime? CompletedAt { get; set; }

        public DateTime? LateAt { get; set; }

        public List<RunStepCommentData>? Comments { get; set; }
    }
}
