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
    public class BookmarksController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Bookmarks
        public IQueryable<Bookmark> GetBookmarks()
        {
            return db.Bookmarks;
        }

        // GET: api/Bookmarks/5
        [ResponseType(typeof(Bookmark))]
        public IHttpActionResult GetBookmark(int id)
        {
            Bookmark bookmark = db.Bookmarks.Find(id);
            if (bookmark == null)
            {
                return NotFound();
            }

            return Ok(bookmark);
        }
          // GET: api/Bookmarks/5
        [ResponseType(typeof(Bookmark))]
        [Route("api/Bookmark/getllist")]
        public IQueryable<Bookmark> GetReaderBookmark(int id)
        {
            return db.Bookmarks.Where(x=>x.READER_FID == id);
          
        }

        // PUT: api/Bookmarks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBookmark(int id, Bookmark bookmark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookmark.BOOKMARK_ID)
            {
                return BadRequest();
            }

            db.Entry(bookmark).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookmarkExists(id))
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

        // POST: api/Bookmarks
        [ResponseType(typeof(Bookmark))]
        [Route("api/Bookmark/addbookmark")]
        public IHttpActionResult PostBookmark(Bookmark bookmark)
        {
            if (!db.Bookmarks.Any(x => x.ARTIFACT_FID == bookmark.ARTIFACT_FID && x.READER_FID == bookmark.READER_FID))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Bookmarks.Add(bookmark);
                db.SaveChanges();
            
            return StatusCode(HttpStatusCode.Created);}
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        } 
        // POST: api/Bookmarks
        [ResponseType(typeof(Bookmark))]
        [Route("api/Bookmark/addtobookmark")]
        public IHttpActionResult AddBookmark(int artid, int readerid)
        {
            Bookmark bookmark = new Bookmark();
            bookmark.ARTIFACT_FID = artid;
            bookmark.READER_FID = readerid;
                
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bookmarks.Add(bookmark);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.Created);
        }

        // DELETE: api/Bookmarks/5
        [ResponseType(typeof(Bookmark))]
        [Route("api/Bookmark/remove")]
        public IHttpActionResult DeleteBookmark(int id)
        {
            Bookmark bookmark = db.Bookmarks.Find(id);
            if (bookmark == null)
            {
                return NotFound();
            }

            db.Bookmarks.Remove(bookmark);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookmarkExists(int id)
        {
            return db.Bookmarks.Count(e => e.BOOKMARK_ID == id) > 0;
        }
    }
}