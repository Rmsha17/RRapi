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
    public class ArtifactsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Artifacts
        public IQueryable<Artifact> GetArtifacts()
        {
            return db.Artifacts;
        }
        [HttpGet]
        [Route("api/Artifact/invoice")]
        public IQueryable<Order_Details> Invoice(int id)
        {
            return db.Order_Details.Where(x => x.ORDER_FID == id);
        }
        [Route("api/Artifact/topratedcomics")]
        public IQueryable<Artifact> GetratedArtifacts()
        {
            var list = db.Artifacts.Where(x => x.SubCategory.Category.CATEGORY_NAME == "Comics");
            return list.OrderByDescending(x => x.Views.Count()).Take(6);
        }
        [Route("api/Artifact/topratednovels")]
        public IQueryable<Artifact> GetratedNArtifacts()
        {
            var list = db.Artifacts.Where(x => x.SubCategory.Category.CATEGORY_NAME == "Novels");
            return list.OrderByDescending(x => x.Views.Count()).Take(6);

        }
        [Route("api/Artifact/topratedromance")]
        public IQueryable<Artifact> GetratedRArtifacts()
        {
            var list = db.Artifacts.Where(x => x.SubCategory.SUB_CATEGORY_NAME == "Romance");
            return list.OrderByDescending(x => x.Views.Count()).Take(6);

        }
        [Route("api/Artifact/topratedhorror")]
        public IQueryable<Artifact> GetratedComedyArtifacts()
        {
            var list = db.Artifacts.Where(x => x.SubCategory.SUB_CATEGORY_NAME == "Horror");
            return list.OrderByDescending(x => x.Views.Count()).Take(6);

        }
        [Route("api/Artifact/topfeatured")]
        public IQueryable<Artifact> GetratedFeaturedArtifacts()
        {

            var list = db.Artifacts;
            return list.OrderByDescending(x => x.Views.Count()).Take(6);
        }
        [Route("api/Artifact/topnewest")]
        public IQueryable<Artifact> GetratednewestArtifacts()
        {

            var list = db.Artifacts;
            return list.OrderByDescending(x => x.ARTIFACT_ID).Take(6);
           
        }

        // GET: api/Artifacts/5
        [ResponseType(typeof(Artifact))]
        [Route("api/Artifacts/getartifact")]
        public IHttpActionResult GetArtifact(int id)
        {
            Artifact artifact = db.Artifacts.Find(id);
            if (artifact == null)
            {
                return NotFound();
            }

            return Ok(artifact);
        }

        // PUT: api/Artifacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArtifact(int id, Artifact artifact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artifact.ARTIFACT_ID)
            {
                return BadRequest();
            }

            db.Entry(artifact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtifactExists(id))
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

        // POST: api/Artifacts
        [ResponseType(typeof(Artifact))]
        public IHttpActionResult PostArtifact(Artifact artifact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Artifacts.Add(artifact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = artifact.ARTIFACT_ID }, artifact);
        }

        // DELETE: api/Artifacts/5
        [ResponseType(typeof(Artifact))]
        public IHttpActionResult DeleteArtifact(int id)
        {
            Artifact artifact = db.Artifacts.Find(id);
            if (artifact == null)
            {
                return NotFound();
            }

            db.Artifacts.Remove(artifact);
            db.SaveChanges();

            return Ok(artifact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtifactExists(int id)
        {
            return db.Artifacts.Count(e => e.ARTIFACT_ID == id) > 0;
        }
    }
}