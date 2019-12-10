using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Results;

namespace ObjectiveLnk.Controllers
{
    public class ObrController : ApiController
    {
        // GET: api/Obr
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Obr/fA5642034
        public IHttpActionResult Get(String id)
        {
            byte[] textAsBytes = Encoding.Unicode.GetBytes(id);

            MemoryStream stream = new MemoryStream(textAsBytes);

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(stream)
            };
            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = id + ".obr"
            };
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/objective");

            ResponseMessageResult responseMessageResult = ResponseMessage(httpResponseMessage);
            return responseMessageResult;
            /*
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(id);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/objective");
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = id + ".obr";
            
          return response;
            */
        }

        // POST: api/Obr
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Obr/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Obr/5
        public void Delete(int id)
        {
        }
    }
}
