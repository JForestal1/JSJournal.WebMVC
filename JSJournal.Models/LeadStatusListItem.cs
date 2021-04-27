using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Models
{
    public class LeadStatusListItem
    {

        [Display(Name = "Status ID")]
        public int StatusTypeID { get; set; }
        [Display(Name = "Status Name")]
        public string Status { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
