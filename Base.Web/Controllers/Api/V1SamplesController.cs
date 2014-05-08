using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Base.Services;
using Base.Models;

namespace Base.Web.Controllers.Api
{
    [RoutePrefix("api/v1/samples")]
    public class V1SamplesController : ApiController
    {
        private readonly ISampleService sampleService;

        public V1SamplesController(ISampleService sampleService)
        {
            this.sampleService = sampleService;
        }

        [Route("")]
        public IEnumerable<Sample> Get()
        {
            return sampleService.GetSamples();
        }

        [Route("{id:int}")]
        public Sample Get(int id)
        {
            return sampleService.GetSample(id);
        }
    }
}
