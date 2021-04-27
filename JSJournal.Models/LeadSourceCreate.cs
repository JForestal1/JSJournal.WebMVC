using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Models
{
    public class LeadSourceCreate
    {
        [Display(Name = "Source Name")]
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 3 characters.")]
        [MaxLength(25, ErrorMessage = "There are too many characters in this field.")]
        public string Source { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }
    }
}
