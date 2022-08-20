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
using RRapi.Models;

namespace RRapi.Controllers
{
    public class WritersController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Writers
        [Route("api/Writer/getwriters")]
        public IQueryable<Writer> GetWriters()
        {
            return db.Writers.Where(x=>x.STATUS == 1);
        }

        // GET: api/Writers/5
        [ResponseType(typeof(Writer))]
        public IHttpActionResult GetWriter(int id)
        {
            Writer writer = db.Writers.Find(id);
            if (writer == null)
            {
                return NotFound();
            }

            return Ok(writer);
        }

        // PUT: api/Writers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWriter(int id, Writer writer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != writer.WRITER_ID)
            {
                return BadRequest();
            }

            db.Entry(writer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WriterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Writers
        [ResponseType(typeof(Writer))]
        public IHttpActionResult PostWriter(Writer writer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Writers.Add(writer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = writer.WRITER_ID }, writer);
        }

        // DELETE: api/Writers/5
        [ResponseType(typeof(Writer))]
        public IHttpActionResult DeleteWriter(int id)
        {
            Writer writer = db.Writers.Find(id);
            if (writer == null)
            {
                return NotFound();
            }

            db.Writers.Remove(writer);
            db.SaveChanges();

            return Ok(writer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WriterExists(int id)
        {
            return db.Writers.Count(e => e.WRITER_ID == id) > 0;
        }
    }
}