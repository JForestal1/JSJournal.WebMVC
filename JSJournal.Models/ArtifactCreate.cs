using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JSJournal.Data.Artifact;

namespace JSJournal.Models
{
    public class ArtifactCreate
    {

        [Display(Name = "Artifact Type")]
        [Required]
        public ArtifactTypes ArtifactType { get; set; }

        [Display(Name = "Label")]
        [MinLength(2, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(25, ErrorMessage = "There are too many characters in this field.")]
        [Required]
        public string ShortLabel { get; set; }

        [Display(Name = "Description")]
        [MinLength(2, ErrorMessage = "Please enter at least 3 characters.")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Link")]
        [Required]
        public string Link { get; set; }

        [Display(Name = "Date and Time Created")]
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Date and Time Last Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
