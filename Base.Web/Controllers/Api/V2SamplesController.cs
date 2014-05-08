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
    [RoutePrefix("api/v2/samples")]
    public class V2SamplesController : ApiController
    {
        private readonly ISampleService sampleService;

        public V2SamplesController(ISampleService sampleService)
        {
            this.sampleService = sampleService;
        }

        [Route("")]
        public IEnumerable<Sample> Get()
        {
            throw new NotImplementedException();
        }
    }
}
