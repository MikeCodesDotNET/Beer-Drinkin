using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace BeerDrinkin.Service.Manager.Controllers
{
    public class BreweryDBWebHookController : ApiController
    {
        // GET api/values
        [SwaggerOperation("GetAll")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/post
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post(string value)
        {
            if (IsValidRequest(value))
            {
                
            }
        }

        public bool IsValidRequest(string value)
        {
            var apiKey = "";
            

            return true;
        }
      
    }
}
