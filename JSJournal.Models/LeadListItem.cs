using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JSJournal.Data.Artifact;

namespace JSJournal.Models
{
    public class LeadListItem
    {

        [Display(Name = "Lead ID")]
        public int LeadID { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Source")]
        public string Source { get; set; }

        [Display(Name = "Job Link")]
        public string JobDescriptionLink { get; set; }

        // Need follow ups and interviews

        [Display(Name = "Follow-up Count")]
        public int FollowUpCount { get; set; }

        [Display(Name = "Resume Used")]
        public string ResumeUsed { get; set; }

        [Display(Name = "Cover Used")]
        public string CoverUsed { get; set; }

        [Display(Name = "Other Artifact Used")]
        public string OtherArtifactUsed { get; set; }

        [Display(Name = "Created")]
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
