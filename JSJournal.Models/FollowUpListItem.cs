using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JSJournal.Data.Artifact;

namespace JSJournal.Models
{
    public class FollowUpListItem
    {

        [Display(Name = "Follow-up ID")]
        public int FollowUpID { get; set; }

        [Display(Name = "Lead ID")]
        public int LeadID { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Status")]
        public String FollowUpStatus { get; set; }

        [Display(Name = "Full Description")]
        public string Notes { get; set; }

        // Need interviews

        [Display(Name = "Due Date")]
        public DateTimeOffset DueUtc { get; set; }

        [Display(Name = "Created")]
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
