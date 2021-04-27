using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Models
{
    public class LeadSourceListItem
    {

        [Display(Name = "Source ID")]
        public int SourceTypeID { get; set; }
        [Display(Name = "Source Name")]
        public string Source { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
