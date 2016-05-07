using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectsManager.Interfaces.Authors;
using ObjectsManager.LiteDB.Authors;
using ObjectsManager.Model;

namespace WebApplication1.Controllers
{
    public class AuthorsController : ApiController
    {
        private readonly IAuthorsRepository _authorsRepository = new AuthorsRepository();

        // GET api/Authors
        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, _authorsRepository.GetAll());
        }

        // GET api/Authors/5
        public HttpResponseMessage Get(int id)
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, _authorsRepository.Get(id));
        }

        // POST api/Authors
        public HttpResponseMessage Post([FromBody]Author value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _authorsRepository.Add(value));
        }

        // PUT api/Authors/5
        public HttpResponseMessage Put(int id, [FromBody]Author value)
        {
            value.ID = id;

            return Request.CreateResponse(HttpStatusCode.OK, _authorsRepository.Update(value));
        }

        // DELETE api/Authors/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _authorsRepository.Delete(id));
        }
    }
}