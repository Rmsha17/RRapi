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
    public class EpisodesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Episodes
        [Route("api/Episode/getepisode")]
        public IQueryable<Episode> GetEpisodes()
        {
            return db.Episodes;
        }
        // GET: api/Episodes
        [Route("api/Episode/getepisodesbyid")]
        public IQueryable<Episode> GetidEpisodes(int id)
        {
            return db.Episodes.Where(x=>x.ARTIFACT_FID == id);
        }

        // GET: api/Episodes/5
        [ResponseType(typeof(Episode))]
        public IHttpActionResult GetEpisode(int id)
        {
            Episode episode = db.Episodes.Find(id);
            if (episode == null)
            {
                return NotFound();
            }

            return Ok(episode);
        }

        // PUT: api/Episodes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEpisode(int id, Episode episode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != episode.EPISODE_ID)
            {
                return BadRequest();
            }

            db.Entry(episode).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpisodeExists(id))
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

        // POST: api/Episodes
        [ResponseType(typeof(Episode))]
        public IHttpActionResult PostEpisode(Episode episode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Episodes.Add(episode);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = episode.EPISODE_ID }, episode);
        }

        // DELETE: api/Episodes/5
        [ResponseType(typeof(Episode))]
        public IHttpActionResult DeleteEpisode(int id)
        {
            Episode episode = db.Episodes.Find(id);
            if (episode == null)
            {
                return NotFound();
            }

            db.Episodes.Remove(episode);
            db.SaveChanges();

            return Ok(episode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EpisodeExists(int id)
        {
            return db.Episodes.Count(e => e.EPISODE_ID == id) > 0;
        }
    }
}