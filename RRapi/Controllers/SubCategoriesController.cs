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
    public class SubCategoriesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/SubCategories
        [Route("api/Subcategory/getsubcategories")]
        public IQueryable<SubCategory> GetSubCategories()
        {
            return db.SubCategories;
        }
        [Route("api/Subcategory/getidsubcategories")]
        public IQueryable<SubCategory> GetSubCategories(int id)
        {
            return  db.SubCategories.Where(x => x.CATEGORY_FID == id);
            
        }
         [Route("api/Artifact/getartifactbysubid")]
        public IQueryable<Artifact> Getartifactsbyid(int id)
        {
            return db.Artifacts.Where(x => x.SUB_CATEGORY_FID == id);
            
        }

        // GET: api/SubCategories/5
        [ResponseType(typeof(SubCategory))]
        
        public IHttpActionResult GetSubCategory(int id)
        {
            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return Ok(subCategory);
        }

        // PUT: api/SubCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubCategory(int id, SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subCategory.SUB_CATEGORY_ID)
            {
                return BadRequest();
            }

            db.Entry(subCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryExists(id))
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

        // POST: api/SubCategories
        [ResponseType(typeof(SubCategory))]
        public IHttpActionResult PostSubCategory(SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubCategories.Add(subCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subCategory.SUB_CATEGORY_ID }, subCategory);
        }

        // DELETE: api/SubCategories/5
        [ResponseType(typeof(SubCategory))]
        public IHttpActionResult DeleteSubCategory(int id)
        {
            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            db.SubCategories.Remove(subCategory);
            db.SaveChanges();

            return Ok(subCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubCategoryExists(int id)
        {
            return db.SubCategories.Count(e => e.SUB_CATEGORY_ID == id) > 0;
        }
    }
}