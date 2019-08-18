
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DatabaseContext : DbContext
    {
        //public DatabaseContext()
        //    : base("DefaultConnection")
        //{

        //}
        public DatabaseContext(): base("DefaultConnection")
        {
            Database.SetInitializer<DatabaseContext>(null);
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = 120;
        }

        public DbSet<Events> Events { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<PopularTags> PopularTags { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
