﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERDSPortal.Models
{
    public class Events
    {
        public int EventID { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
    }
}