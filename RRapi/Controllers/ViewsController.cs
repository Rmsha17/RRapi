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
    public class ViewsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Views
        public IQueryable<View> GetViews()
        {
            return db.Views;
        }

        // GET: api/Views/5
        [ResponseType(typeof(View))]
        public IHttpActionResult GetView(int id)
        {
            View view = db.Views.Find(id);
            if (view == null)
            {
                return NotFound();
            }

            return Ok(view);
        }

        // PUT: api/Views/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutView(int id, View view)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != view.VIEW_ID)
            {
                return BadRequest();
            }

            db.Entry(view).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewExists(id))
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

        // POST: api/Views
        [ResponseType(typeof(View))]
        [Route("api/View/postview")]
        public IHttpActionResult PostView(View view)
        {
            if(!db.Views.Any(x => x.READER_FID == view.READER_FID && x.EPISODE_FID == view.EPISODE_FID)) 
            { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Views.Add(view);
            db.SaveChanges();
            }
            return StatusCode(HttpStatusCode.Created);
        }

        // DELETE: api/Views/5
        [ResponseType(typeof(View))]
        public IHttpActionResult DeleteView(int id)
        {
            View view = db.Views.Find(id);
            if (view == null)
            {
                return NotFound();
            }

            db.Views.Remove(view);
            db.SaveChanges();

            return Ok(view);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViewExists(int id)
        {
            return db.Views.Count(e => e.VIEW_ID == id) > 0;
        }
    }
}