using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JSJournal.Data.Artifact;

namespace JSJournal.Models
{
    public class ArtifactListItem
    {

        [Display(Name = "Artifact ID")]
        public int ArtifactID { get; set; }

        [Display(Name = "Artifact Type")]
        public ArtifactTypes ArtifactType { get; set; }

        [Display(Name = "Label")]
        public string ShortLabel { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Link")]
        public string Link { get; set; }

        [Display(Name = "Date and Time Created")]
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Date and Time Last Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
