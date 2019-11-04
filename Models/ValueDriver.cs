using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ERDSPortal.Models
{
    public class ValueDriver
    {
        public int ValueDriverId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Icon { get; set; }

        public virtual ICollection<Accomplishment> Accomplishments { get; set; }
    }

}