using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERDSPortal.Models
{
    public class Accomplishment
    {

        public int AccomplishmentId { get; set; }
        public DateTime Date { get; set; }

        [DisplayName("Team Name")]
        public string TeamName { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string LinkedContent { get; set; }

        public virtual ICollection<ValueDriver> ValueDrivers { get; set; }

        public virtual ICollection<FocusArea> FocusAreas { get; set; }

        [NotMapped]
        public string ValueDriversSelection { get; set; }
    }


}