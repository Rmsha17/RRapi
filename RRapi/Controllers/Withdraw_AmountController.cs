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
    public class Withdraw_AmountController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Withdraw_Amount
        public IQueryable<Withdraw_Amount> GetWithdraw_Amount()
        {
            return db.Withdraw_Amount;
        }

        // GET: api/Withdraw_Amount/5
        [ResponseType(typeof(Withdraw_Amount))]
        public IHttpActionResult GetWithdraw_Amount(int id)
        {
            Withdraw_Amount withdraw_Amount = db.Withdraw_Amount.Find(id);
            if (withdraw_Amount == null)
            {
                return NotFound();
            }

            return Ok(withdraw_Amount);
        }

        // PUT: api/Withdraw_Amount/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWithdraw_Amount(int id, Withdraw_Amount withdraw_Amount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != withdraw_Amount.ID)
            {
                return BadRequest();
            }

            db.Entry(withdraw_Amount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Withdraw_AmountExists(id))
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

        // POST: api/Withdraw_Amount
        [ResponseType(typeof(Withdraw_Amount))]
        public IHttpActionResult PostWithdraw_Amount(Withdraw_Amount withdraw_Amount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Withdraw_Amount.Add(withdraw_Amount);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = withdraw_Amount.ID }, withdraw_Amount);
        }

        // DELETE: api/Withdraw_Amount/5
        [ResponseType(typeof(Withdraw_Amount))]
        public IHttpActionResult DeleteWithdraw_Amount(int id)
        {
            Withdraw_Amount withdraw_Amount = db.Withdraw_Amount.Find(id);
            if (withdraw_Amount == null)
            {
                return NotFound();
            }

            db.Withdraw_Amount.Remove(withdraw_Amount);
            db.SaveChanges();

            return Ok(withdraw_Amount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Withdraw_AmountExists(int id)
        {
            return db.Withdraw_Amount.Count(e => e.ID == id) > 0;
        }
    }
}