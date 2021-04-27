using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Data
{
    public class PostInterview
    {
        [Key]
        public int PostInterviewID { get; set; }
        public Guid OwnerId { get; set; }
        public string Notes { get; set; }
    }
}
