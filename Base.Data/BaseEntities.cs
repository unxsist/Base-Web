using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Models;
using Base.Data.Configuration;

namespace Base.Data
{
    public class BaseEntities : DbContext
    {
        public BaseEntities() : base("BaseEntities") {

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BaseEntities, BaseMigrationsConfiguration>());
        }

        public DbSet<Sample> Samples { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Add your (optional) model conventions here

            modelBuilder.Configurations.Add(new SampleConfiguration());
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
