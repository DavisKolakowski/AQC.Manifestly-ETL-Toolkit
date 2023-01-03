namespace AQC.Manifestly.Core.Client.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RunStepCommentData
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CommentWithLinks { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Identifier { get; set; }
    }
}
