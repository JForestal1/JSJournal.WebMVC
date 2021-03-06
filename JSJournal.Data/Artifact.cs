using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Data
{
    public class Artifact
    {
        public enum ArtifactTypes
        {
            CoverLetter=1,
            Resume,
            WorkExample,
            Portfolio,
            ReferralLetter,
            Other
        }

        [Key]
        public int ArtifactID { get; set; }
        public Guid OwnerId { get; set; }
        public ArtifactTypes ArtifactType { get; set; }

        public string ShortLabel { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        [Display(Name = "Date and Time Created")]
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Date and Time Last Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
