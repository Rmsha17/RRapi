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
    public class PremiumsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Premiums
        [Route("api/Preiums/getpremium")]
        public IQueryable<Premium> GetPremiums()
        {
            return db.Premiums;
        }

        // GET: api/Premiums/5
        [ResponseType(typeof(Premium))]
        public IHttpActionResult GetPremium(int id)
        {
            Premium premium = db.Premiums.Find(id);
            if (premium == null)
            {
                return NotFound();
            }

            return Ok(premium);
        }

        // PUT: api/Premiums/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPremium(int id, Premium premium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != premium.PREMIUM_ID)
            {
                return BadRequest();
            }

            db.Entry(premium).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremiumExists(id))
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

        // POST: api/Premiums
        [ResponseType(typeof(Premium))]
        public IHttpActionResult PostPremium(Premium premium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Premiums.Add(premium);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = premium.PREMIUM_ID }, premium);
        }

        // DELETE: api/Premiums/5
        [ResponseType(typeof(Premium))]
        public IHttpActionResult DeletePremium(int id)
        {
            Premium premium = db.Premiums.Find(id);
            if (premium == null)
            {
                return NotFound();
            }

            db.Premiums.Remove(premium);
            db.SaveChanges();

            return Ok(premium);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PremiumExists(int id)
        {
            return db.Premiums.Count(e => e.PREMIUM_ID == id) > 0;
        }
    }
}