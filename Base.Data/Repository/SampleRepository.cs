using Base.Data.Infrastructure;
using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Repository
{
    public class SampleRepository : RepositoryBase<Sample>, ISampleRepository
    {
        public SampleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }

    public interface ISampleRepository : IRepository<Sample>
    {
        //Empty interface, add specific methods for your repository here
    }
}
