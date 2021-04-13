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

        public string PrimaryInterviwer { get; set; }

        public string SecondaryInterviwer { get; set; }

        public DateTimeOffset InterviewTimeDateUtc { get; set; }

        public String Address { get; set; }

        public string InterviewerLink { get; set; }

        public string Notes { get; set; }

        [ForeignKey("InterviewNotes")]
        public int? PostInterviewID { get; set; }

        public virtual PostInterview InterviewNotes { get; set; }

    }
}
