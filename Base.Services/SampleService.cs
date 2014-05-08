using Base.Data.Infrastructure;
using Base.Data.Repository;
using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository sampleRepository;
        private readonly IUnitOfWork unitOfWork;

        public SampleService(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
        {
            this.sampleRepository = sampleRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Sample> GetSamples()
        {
            return sampleRepository.GetAll();
        }

        public Sample GetSample(int id)
        {
            return sampleRepository.GetById(id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }

    public interface ISampleService
    {
        IEnumerable<Sample> GetSamples();
        Sample GetSample(int id);
        void Save();
    }
}
