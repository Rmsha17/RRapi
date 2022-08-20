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
    public class WEBSITE_DETAILSController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/WEBSITE_DETAILS
        [Route("api/Website/Getdetails")]
        public WEBSITE_DETAILS GetWEBSITE_DETAILS()
        {
            return db.WEBSITE_DETAILS.FirstOrDefault();
        }

        // GET: api/WEBSITE_DETAILS/5
        [ResponseType(typeof(WEBSITE_DETAILS))]
        public IHttpActionResult GetWEBSITE_DETAILS(int id)
        {
            WEBSITE_DETAILS wEBSITE_DETAILS = db.WEBSITE_DETAILS.Find(id);
            if (wEBSITE_DETAILS == null)
            {
                return NotFound();
            }

            return Ok(wEBSITE_DETAILS);
        }

        // PUT: api/WEBSITE_DETAILS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWEBSITE_DETAILS(int id, WEBSITE_DETAILS wEBSITE_DETAILS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wEBSITE_DETAILS.WEBSITE_ID)
            {
                return BadRequest();
            }

            db.Entry(wEBSITE_DETAILS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WEBSITE_DETAILSExists(id))
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

        // POST: api/WEBSITE_DETAILS
        [ResponseType(typeof(WEBSITE_DETAILS))]
        public IHttpActionResult PostWEBSITE_DETAILS(WEBSITE_DETAILS wEBSITE_DETAILS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WEBSITE_DETAILS.Add(wEBSITE_DETAILS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wEBSITE_DETAILS.WEBSITE_ID }, wEBSITE_DETAILS);
        }

        // DELETE: api/WEBSITE_DETAILS/5
        [ResponseType(typeof(WEBSITE_DETAILS))]
        public IHttpActionResult DeleteWEBSITE_DETAILS(int id)
        {
            WEBSITE_DETAILS wEBSITE_DETAILS = db.WEBSITE_DETAILS.Find(id);
            if (wEBSITE_DETAILS == null)
            {
                return NotFound();
            }

            db.WEBSITE_DETAILS.Remove(wEBSITE_DETAILS);
            db.SaveChanges();

            return Ok(wEBSITE_DETAILS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WEBSITE_DETAILSExists(int id)
        {
            return db.WEBSITE_DETAILS.Count(e => e.WEBSITE_ID == id) > 0;
        }
    }
}