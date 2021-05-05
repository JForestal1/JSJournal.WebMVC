using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JSJournal.Data.Artifact;

namespace JSJournal.Models
{
    public class FollowUpEdit
    {


        public int FollowUpID { get; set; }

        [Display(Name = "Lead ID")]
        public int LeadID { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Status ID")]
        public int FollowUpStatusID { get; set; }

        [Display(Name = "Full Description")]
        public string Notes { get; set; }

        // Need interviews

        [Display(Name = "Due Date")]
        public DateTimeOffset DueUtc { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
