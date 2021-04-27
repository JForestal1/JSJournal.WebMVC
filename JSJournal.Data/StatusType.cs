﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Data
{
    public class StatusType
    {
        [Key]
        public int StatusTypeID { get; set; }
        public Guid OwnerId { get; set; }
        public string Status { get; set; }

        public string Description { get; set; }

    }
}
