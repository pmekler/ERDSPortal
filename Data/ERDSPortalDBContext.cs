using ERDSPortal.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ERDSPortal.Data
{
    public class ERDSPortalDBContext : DbContext
    {

        public ERDSPortalDBContext() : base("ERDSPortalDBContext")
        { }



        public DbSet<Accomplishment> Accomplishments { get; set; }
        public DbSet<ValueDriver> ValueDrivers { get; set; }

        public System.Data.Entity.DbSet<ERDSPortal.Models.FocusArea> FocusAreas { get; set; }
    }
}