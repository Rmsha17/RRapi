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
    public class ShopArtifactsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ShopArtifacts
        [Route("api/ShopArtifacts/getshopartifacts")]
        public IQueryable<ShopArtifact> GetShopArtifacts()
        {
            return db.ShopArtifacts;
        }

        // GET: api/ShopArtifacts/5
        [ResponseType(typeof(ShopArtifact))]
        [Route("api/ShopArtifacts/getidshopartifacts")]
        public IHttpActionResult GetShopArtifact(int id)
        {
            ShopArtifact shopArtifact = db.ShopArtifacts.Find(id);
            if (shopArtifact == null)
            {
                return NotFound();
            }

            return Ok(shopArtifact);
        }

        // PUT: api/ShopArtifacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShopArtifact(int id, ShopArtifact shopArtifact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shopArtifact.ID)
            {
                return BadRequest();
            }

            db.Entry(shopArtifact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopArtifactExists(id))
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

        // POST: api/ShopArtifacts
        [ResponseType(typeof(ShopArtifact))]
        public IHttpActionResult PostShopArtifact(ShopArtifact shopArtifact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShopArtifacts.Add(shopArtifact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shopArtifact.ID }, shopArtifact);
        }

        // DELETE: api/ShopArtifacts/5
        [ResponseType(typeof(ShopArtifact))]
        public IHttpActionResult DeleteShopArtifact(int id)
        {
            ShopArtifact shopArtifact = db.ShopArtifacts.Find(id);
            if (shopArtifact == null)
            {
                return NotFound();
            }

            db.ShopArtifacts.Remove(shopArtifact);
            db.SaveChanges();

            return Ok(shopArtifact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShopArtifactExists(int id)
        {
            return db.ShopArtifacts.Count(e => e.ID == id) > 0;
        }
    }
}