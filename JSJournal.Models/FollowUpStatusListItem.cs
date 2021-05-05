using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Models
{
    public class FollowUpStatusListItem
    {

        [Display(Name = "Follow-up Status ID")]
        public int FollowUpStatusTypeID { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
