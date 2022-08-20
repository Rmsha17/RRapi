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
    public class ReaderPremiumsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ReaderPremiums
        public IQueryable<ReaderPremium> GetReaderPremiums()
        {
            return db.ReaderPremiums;
        }

        // GET: api/ReaderPremiums/5
        [ResponseType(typeof(ReaderPremium))]
        public IHttpActionResult GetReaderPremium(int id)
        {
            ReaderPremium readerPremium = db.ReaderPremiums.Find(id);
            if (readerPremium == null)
            {
                return NotFound();
            }

            return Ok(readerPremium);
        }
        [ResponseType(typeof(ReaderPremium))]
        [Route("api/ReaderPremium/getloggedreader")]
        public IHttpActionResult GetloggedReaderPremium(int id)
        {
            ReaderPremium readerPremium = db.ReaderPremiums.Where(x=>x.READER_FID == id).ToList().LastOrDefault();
            if (readerPremium == null)
            {
                return NotFound();
            }

            return Ok(readerPremium);
        }

        // PUT: api/ReaderPremiums/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReaderPremium(int id, ReaderPremium readerPremium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != readerPremium.BUYPREMIUM_ID)
            {
                return BadRequest();
            }

            db.Entry(readerPremium).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReaderPremiumExists(id))
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

        // POST: api/ReaderPremiums
        [ResponseType(typeof(ReaderPremium))]
        public IHttpActionResult PostReaderPremium(ReaderPremium readerPremium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReaderPremiums.Add(readerPremium);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = readerPremium.BUYPREMIUM_ID }, readerPremium);
        }

        // DELETE: api/ReaderPremiums/5
        [ResponseType(typeof(ReaderPremium))]
        public IHttpActionResult DeleteReaderPremium(int id)
        {
            ReaderPremium readerPremium = db.ReaderPremiums.Find(id);
            if (readerPremium == null)
            {
                return NotFound();
            }

            db.ReaderPremiums.Remove(readerPremium);
            db.SaveChanges();

            return Ok(readerPremium);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReaderPremiumExists(int id)
        {
            return db.ReaderPremiums.Count(e => e.BUYPREMIUM_ID == id) > 0;
        }
    }
}