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
    public class SalaryRatesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/SalaryRates
        public IQueryable<SalaryRate> GetSalaryRates()
        {
            return db.SalaryRates;
        }

        // GET: api/SalaryRates/5
        [ResponseType(typeof(SalaryRate))]
        public IHttpActionResult GetSalaryRate(int id)
        {
            SalaryRate salaryRate = db.SalaryRates.Find(id);
            if (salaryRate == null)
            {
                return NotFound();
            }

            return Ok(salaryRate);
        }

        // PUT: api/SalaryRates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalaryRate(int id, SalaryRate salaryRate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salaryRate.ID)
            {
                return BadRequest();
            }

            db.Entry(salaryRate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryRateExists(id))
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

        // POST: api/SalaryRates
        [ResponseType(typeof(SalaryRate))]
        public IHttpActionResult PostSalaryRate(SalaryRate salaryRate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SalaryRates.Add(salaryRate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = salaryRate.ID }, salaryRate);
        }

        // DELETE: api/SalaryRates/5
        [ResponseType(typeof(SalaryRate))]
        public IHttpActionResult DeleteSalaryRate(int id)
        {
            SalaryRate salaryRate = db.SalaryRates.Find(id);
            if (salaryRate == null)
            {
                return NotFound();
            }

            db.SalaryRates.Remove(salaryRate);
            db.SaveChanges();

            return Ok(salaryRate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalaryRateExists(int id)
        {
            return db.SalaryRates.Count(e => e.ID == id) > 0;
        }
    }
}