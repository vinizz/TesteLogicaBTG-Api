using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteBTGApi.Repository;

namespace TesteBTGApi.Controllers
{
    [RoutePrefix("api/teste")]
    public class TesteController : ApiController
    {
        private readonly CortarRepository _cortarRepository = new CortarRepository();

        [HttpGet]
        [Route("cortarTijolo")]
        public HttpResponseMessage CortarTijolo([FromBody] List<int[]> values)
        {
            try
            {
                int max_int;
                max_int = Convert.ToInt32(values[0].Sum());

                List<int[]> parede = values;
                string msg = _cortarRepository.CortarTijolo(parede, max_int);

                return Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }


    }
}
