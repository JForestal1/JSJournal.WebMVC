using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JSJournal.Data.Artifact;

namespace JSJournal.Models
{
    public class LeadCreate
    {

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }

        [Display(Name = "Status")]
        public int StatusID { get; set; }

        [Display(Name = "Source")]
        public int SourceID { get; set; }

        [Display(Name = "Job Link")]
        public string JobDescriptionLink { get; set; }

        // Need follow ups and interviews

        [Display(Name = "Resume Used")]
        public int? ResumeID { get; set; }

        [Display(Name = "Cover Used")]
        public int? CoverID { get; set; }

        [Display(Name = "Other Artifact Used")]
        public int? OtherArtifactUsedID { get; set; }

        [Display(Name = "Date and Time Created")]
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Date and Time Last Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
