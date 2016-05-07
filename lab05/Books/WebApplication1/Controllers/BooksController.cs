using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectsManager.Interfaces.Books;
using ObjectsManager.LiteDB.Books;
using ObjectsManager.Model;

namespace WebApplication1.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBooksRepository _booksRepository = new BooksRepository();

        // GET api/Books
        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, _booksRepository.GetAll());
        }

        // GET api/Books/5
        public HttpResponseMessage Get(int id)
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, _booksRepository.Get(id));
        }

        // GET api/books?search=query
        public HttpResponseMessage Get([FromUri] string search)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _booksRepository.Get(search));
        }

        // POST api/Books
        public HttpResponseMessage Post([FromBody]Book value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _booksRepository.Add(value));
        }

        // PUT api/Books/5
        public HttpResponseMessage Put(int id, [FromBody]Book value)
        {
            value.ID = id;

            return Request.CreateResponse(HttpStatusCode.OK, _booksRepository.Update(value));
        }

        // DELETE api/Books/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _booksRepository.Delete(id));
        }
    }
}