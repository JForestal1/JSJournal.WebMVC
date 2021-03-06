using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Models
{
    public class InterviewCreate
    {
        public int InterviewID { get; set; }

        [Display(Name = "Lead ID")]
        public int LeadID { get; set; }

        [Display(Name = "Primary Interviewer")]
        public string PrimaryInterviewer { get; set; }

        [Display(Name = "Additional Interviewers")]
        public string SecondaryInterviewer { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Interviewer Link")]
        public string InterviewerLink { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        // Need interviews

        [Display(Name = "Interview Date")]
        public DateTimeOffset InterviewTimeDateUtc { get; set; }

    }
}
