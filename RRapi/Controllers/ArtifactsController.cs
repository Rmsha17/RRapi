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
using Newtonsoft.Json;
using OpenXmlPowerTools;
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
        public List<Artifact> Invoice(int id)
        {
            var list = db.Order_Details.Where(x => x.ORDER_FID == id);
            var RefinedList = new List<Artifact>();
            foreach (var item in list)
            {
                var shopart = db.ShopArtifacts.Where(x => x.ID == item.SHOPARTIFACT_FID).FirstOrDefault();
                var art = db.Artifacts.Where(x => x.ARTIFACT_ID == shopart.ARTIFACT_FID).FirstOrDefault();
                art.shopartidactid = shopart.ID;
                art.PURCHASE_PRICE = shopart.PURCHASE_PRICE;
                art.SALE_PRICE = shopart.SALE_PRICE;
                RefinedList.Add(art);
            }
            return RefinedList;

        }
        [Route("api/Artifact/topratedcomics")]
        public List<Artifact> GetratedArtifacts()
        {
            var list = db.Artifacts.Where(x => x.SubCategory.Category.CATEGORY_NAME == "Comics").OrderByDescending(x => x.Views.Count()).Take(6);
            
            var RefinedList = new List<Artifact>();
            foreach (var item in list)
            {
                var cat = db.SubCategories.Where(x => x.SUB_CATEGORY_ID == item.SUB_CATEGORY_FID).FirstOrDefault();
                item.SubCategory_Name = cat.SUB_CATEGORY_NAME;
                RefinedList.Add(item);
            }
            return RefinedList;
        }
        [Route("api/Artifact/topratednovels")]
        public List<Artifact> GetratedNArtifacts()
        {
            var list = db.Artifacts.Where(x => x.SubCategory.Category.CATEGORY_NAME == "Novels").OrderByDescending(x => x.Views.Count()).Take(6);

            var RefinedList = new List<Artifact>();
            foreach (var item in list)
            {
                var cat = db.SubCategories.Where(x => x.SUB_CATEGORY_ID == item.SUB_CATEGORY_FID).FirstOrDefault();
                item.SubCategory_Name = cat.SUB_CATEGORY_NAME;
                RefinedList.Add(item);
            }
            return RefinedList;
        }
        [Route("api/Artifact/topratedromance")]
        public List<Artifact> GetratedRArtifacts()
        {
           

            var list = db.Artifacts.Where(x => x.SubCategory.SUB_CATEGORY_NAME == "Romance").OrderByDescending(x => x.Views.Count()).Take(6);

            var RefinedList = new List<Artifact>();
            foreach (var item in list)
            {
                var cat = db.SubCategories.Where(x => x.SUB_CATEGORY_ID == item.SUB_CATEGORY_FID).FirstOrDefault();
                item.SubCategory_Name = cat.SUB_CATEGORY_NAME;
                RefinedList.Add(item);
            }
            return RefinedList;
        }
        [Route("api/Artifact/topratedhorror")]
        public List<Artifact> GetratedComedyArtifacts()
        {
           
            var list = db.Artifacts.Where(x => x.SubCategory.SUB_CATEGORY_NAME == "Horror").OrderByDescending(x => x.Views.Count()).Take(6);

            var RefinedList = new List<Artifact>();
            foreach (var item in list)
            {
                var cat = db.SubCategories.Where(x => x.SUB_CATEGORY_ID == item.SUB_CATEGORY_FID).FirstOrDefault();
                item.SubCategory_Name = cat.SUB_CATEGORY_NAME;
                RefinedList.Add(item);
            }
            return RefinedList;

        }
        [Route("api/Artifact/topfeatured")]
        public List<Artifact> GetratedFeaturedArtifacts()
        {
            var list = db.Artifacts.OrderByDescending(x => x.Views.Count()).Take(6);

            var RefinedList = new List<Artifact>();
            foreach (var item in list)
            {
                var cat = db.SubCategories.Where(x => x.SUB_CATEGORY_ID == item.SUB_CATEGORY_FID).FirstOrDefault();
                item.SubCategory_Name = cat.SUB_CATEGORY_NAME;
                RefinedList.Add(item);
            }
            return RefinedList;
        }
        [Route("api/Artifact/topnewest")]
        public List<Artifact> GetratednewestArtifacts()
        {
            var list = db.Artifacts.OrderByDescending(x => x.ARTIFACT_ID).Take(6);

            var RefinedList = new List<Artifact>();
            foreach (var item in list)
            {
                var cat = db.SubCategories.Where(x => x.SUB_CATEGORY_ID == item.SUB_CATEGORY_FID).FirstOrDefault();
                item.SubCategory_Name = cat.SUB_CATEGORY_NAME;
                RefinedList.Add(item);
            }
            return RefinedList;
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