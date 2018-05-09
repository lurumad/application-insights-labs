using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationInsightsLabs.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly TelemetryClient telemetryClient;

        public ValuesController(TelemetryClient telemetryClient)
        {
            this.telemetryClient = telemetryClient;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                var result = 1 / id;
            }
            catch (Exception ex)
            {
                telemetryClient.TrackException(ex);
            }

            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
