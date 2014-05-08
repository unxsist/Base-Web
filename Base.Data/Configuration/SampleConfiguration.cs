using Base.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Configuration
{
    public class SampleConfiguration : EntityTypeConfiguration<Sample>
    {
        public SampleConfiguration()
        {
            HasKey(s => s.Id);
            Property(s => s.Name).IsRequired().HasMaxLength(100);
            Property(s => s.CreatedDate).IsRequired();
        }
    }
}
