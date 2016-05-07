using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Museum.Interfaces;
using Museum.Models;
using Museum.Log4Net;

namespace Museum.Controllers
{
    public class PaintingsController : ApiController
    {
        private readonly IPaintingsRepository _pr;
        private readonly ILogger _logger;

        public PaintingsController(IPaintingsRepository pr, ILogger logger)
        {
            _pr = pr;
            _logger = logger;
        }

        public IEnumerable<Painting> GetPaintings()
        {
            _logger.Write("GET for paintings was called", LogLevel.INFO);
            return _pr.GetAll();
        }

        public IHttpActionResult GetPainting(int id)
        {
            _logger.Write("GET for painting was called", LogLevel.INFO);
            Painting painting = _pr.Get(id);
            if (painting == null)
            {
                return NotFound();
            }

            return Ok(painting);
        }

        [ResponseType(typeof(Painting))]
        public IHttpActionResult PutPainting(int id, Painting painting)
        {
            _logger.Write("PUT for painting was called", LogLevel.INFO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != painting.ID)
            {
                return BadRequest();
            }

            Painting p = _pr.Update(painting);
            if (p == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [ResponseType(typeof(Painting))]
        public IHttpActionResult PostPainting(Painting painting)
        {
            _logger.Write("POST for painting was called", LogLevel.INFO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _pr.Add(painting);

            return Ok(painting.ID);
        }

        public IHttpActionResult DeletePainting(int id)
        {
            _logger.Write("DELETE for painting was called", LogLevel.INFO);
            if (!_pr.Delete(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}