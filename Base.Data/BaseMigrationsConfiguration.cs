using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace Base.Data
{
    public class BaseMigrationsConfiguration : DbMigrationsConfiguration<BaseEntities>
    {
        public BaseMigrationsConfiguration()
        {
#if DEBUG
            this.AutomaticMigrationDataLossAllowed = true;
#endif

            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BaseEntities context)
        {
            base.Seed(context);

#if DEBUG
            //Seed the database, executed everytime a new appdomain starts.
            if(context.Samples.Count() == 0)
            {
                context.Samples.Add(new Models.Sample() { 
                    Name = "Sample 1"
                });

                context.Samples.Add(new Models.Sample()
                {
                    Name = "Sample 2"
                });

                context.Samples.Add(new Models.Sample()
                {
                    Name = "Sample 3"
                });

                context.Samples.Add(new Models.Sample()
                {
                    Name = "Sample 4"
                });

                context.Samples.Add(new Models.Sample()
                {
                    Name = "Sample 5"
                });

                context.SaveChanges();
            }
#endif
        }
    }
}
