using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Data
{
    public class FollowUp
    {
        [Key]
        public int FollowUpID { get; set; }

        public string ShortDescription { get; set; }

        [ForeignKey("Status")]
        public int FollowUpStatusID { get; set; }
        public virtual FollowUpStatusType Status { get; set; }

        public string Notes { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public DateTimeOffset DueUtc { get; set; }

    }
}
