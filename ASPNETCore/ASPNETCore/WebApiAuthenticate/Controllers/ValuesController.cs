using ASPNETCore.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;

namespace ASPNETCore.WebApiAuthenticate.Controllers
{
    [BasicAuthentication]
    [RequireHttps]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST api/values
        public HttpResponseMessage Post()
        {
            var response = Request.CreateResponse<string>(System.Net.HttpStatusCode.Created, "Your first POST request!");
            return response;
        }
        public HttpResponseMessage Post(int id)
        {

            var response = Request.CreateResponse<string>(System.Net.HttpStatusCode.Created, id.ToString());
            return response;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
