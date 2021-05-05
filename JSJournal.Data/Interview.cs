using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Data
{
    public class Interview
    {

        [Key]
        public int InterviewID { get; set; }
        public Guid OwnerID { get; set; }

        [ForeignKey("Lead")]
        public int LeadID { get; set; }
        public virtual Lead Lead { get; set; }

        public string PrimaryInterviewer { get; set; }

        public string SecondaryInterviewer { get; set; }

        public DateTimeOffset InterviewTimeDateUtc { get; set; }

        public string Address { get; set; }

        public string InterviewerLink { get; set; }

        public string Notes { get; set; }

    }
}
