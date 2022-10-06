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
    public class FeedbacksController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Feedbacks
        [Route("api/Feedback/getfeedbacks")]
        public IQueryable<Feedback> GetFeedbacks()
        {
            return db.Feedbacks.OrderByDescending(x=>x.FEEDBACK_ID);
        }
         [Route("api/Feedback/getartfeedbacks")]
        public List<Feedback> GetArtFeedbacks(int id)
        {
          var list =db.Feedbacks.Where(x=>x.ARTIFACT_FID == id && x.FEEDBACK_FID == null).OrderByDescending(x=>x.FEEDBACK_ID);
          var RefinedList = new List<Feedback>();
            foreach (var item in list)
            {
                var cat = db.Readers.Where(x => x.READER_ID == item.READER_FID).FirstOrDefault();
                item.READER_NAME = cat.READER_NAME;
                item.READER_IMAGE = cat.READER_IMAGE;
                RefinedList.Add(item);
            }
            return RefinedList;
        }

        // GET: api/Feedbacks/5
        [ResponseType(typeof(Feedback))]
        public IHttpActionResult GetFeedback(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        // PUT: api/Feedbacks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeedback(int id, Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.FEEDBACK_ID)
            {
                return BadRequest();
            }

            db.Entry(feedback).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id))
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

        // POST: api/Feedbacks
        [ResponseType(typeof(Feedback))]
        [Route("api/Feedback/postfeedback")]
        public IHttpActionResult PostFeedback(Feedback feedback)
        {
            feedback.FEEDBACK_DATE = System.DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Feedbacks.Add(feedback);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.Created);
        }

        // DELETE: api/Feedbacks/5
        [ResponseType(typeof(Feedback))]
        public IHttpActionResult DeleteFeedback(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }

            db.Feedbacks.Remove(feedback);
            db.SaveChanges();

            return Ok(feedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedbackExists(int id)
        {
            return db.Feedbacks.Count(e => e.FEEDBACK_ID == id) > 0;
        }
    }
}