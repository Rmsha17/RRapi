using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Firebase.Storage;
using RRapi.Models;

namespace RRapi.Controllers
{
    public class ReadersController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Readers
        [Route("api/readers/getreader")]
        public IQueryable<Reader> GetReaders()
        {
            return db.Readers;
        }
        // GET: api/Readers
        [Route("api/readers/getorderhistory")]
        public List<Order> Getorderhistory(int id)
        {
            var list = db.Orders.Where(x => x.ORDER_TYPE == "Sale" && x.ORDER_STATUS == "Booked" && x.READER_FID == id);
            var RefinedList = new List<Order>();
            foreach (var item in list)
            {
                var cat = db.Readers.Where(x => x.READER_ID == item.READER_FID).FirstOrDefault();
                item.Reader_Name = cat.READER_NAME ;
                RefinedList.Add(item);
            }
            return RefinedList;
        }
        // GET: api/Readers
        [Route("api/readers/getordercancel")]
        public List<Order> Getordercancel(int id)
        {
          var list = db.Orders.Where(x => x.ORDER_TYPE == "Sale" && x.ORDER_STATUS == "Cancelled" && x.READER_FID == id);
            var RefinedList = new List<Order>();
            foreach (var item in list)
            {
                var cat = db.Readers.Where(x => x.READER_ID == item.READER_FID).FirstOrDefault();
                item.Reader_Name = cat.READER_NAME;
                RefinedList.Add(item);
            }
            return RefinedList;
        }

        // GET: api/Readers/5
        [ResponseType(typeof(Reader))]
        public IHttpActionResult GetReader(int id)
        {
            Reader reader = db.Readers.Find(id);
            if (reader == null)
            {
                return NotFound();
            }

            return Ok(reader);
        }
        // GET: api/Readers/
        [HttpGet]
        [ResponseType(typeof(Reader))]
        [Route("api/readers/loginchk")]
        public IHttpActionResult LoginCheck(string email, string password)
        {

            Reader login = db.Readers.FirstOrDefault(x => x.READER_EMAIL == email && x.READER_PASSWORD == password);
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }
        [HttpGet]
        [ResponseType(typeof(Reader))]
        [Route("api/readers/forgotpassword")]
        public IHttpActionResult ForgotPassword(string email)
        {

            Reader login = db.Readers.FirstOrDefault(x => x.READER_EMAIL == email);
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        // PUT: api/Readers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReader(int id, Reader reader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reader.READER_ID)
            {
                return BadRequest();
            }

            db.Entry(reader).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReaderExists(id))
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

        // POST: api/Readers
        [Route("api/readers/postreader")]
        [ResponseType(typeof(Reader))]
        public IHttpActionResult PostReader(Reader reader)
        {
            if (!db.Readers.Any(x => x.READER_EMAIL == reader.READER_EMAIL))
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Readers.Add(reader);
                db.SaveChanges();

                ReaderPremium readerpre = new ReaderPremium();
                readerpre.READER_FID = reader.READER_ID;
                readerpre.PREMIUM_FID = 7;
                readerpre.BUY_DATE = System.DateTime.Now;
                readerpre.PREMIUM_END_DATE = readerpre.BUY_DATE.AddMonths(1);
                db.ReaderPremiums.Add(readerpre);
                db.SaveChanges();

                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return BadRequest("Email Already Existed!!");
            }

        }

        // DELETE: api/Readers/5
        [ResponseType(typeof(Reader))]
        [Route("api/Reader/removereader")]
        public IHttpActionResult DeleteReader(int id)
        {
            Reader reader = db.Readers.Find(id);
            if (reader == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                reader.IS_ACCOUNT_ACTIVATE = false;
                db.Entry(reader).State = EntityState.Modified;
                db.SaveChanges();
            }
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

        private bool ReaderExists(int id)
        {
            return db.Readers.Count(e => e.READER_ID == id) > 0;
        }

        [HttpPost]
        [Route("api/readers/postimage")]
        public async Task<string> PostcloudImage()
        {

            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file1 in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file1];

                        var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                        var stroageImage = await new FirebaseStorage("readrixfiles.appspot.com")
                        .Child("ItemImages")
                               .Child(Guid.NewGuid().ToString() + fileName)
                               .PutAsync(postedFile.InputStream);
                        string imgurl = stroageImage;
                        return imgurl;

                    }
                }
            }
            catch (Exception exception)
            {
                return exception.Message + " - Server Error";
            }

            return "No Image Found or Somthing Went Wrong";
        }



        [HttpPost]
        [Route("api/reader/postserverimage")]
        public string PostImage()
        {

            try
            {
                var httpRequest = HttpContext.Current.Request;

                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        //var uploadLocation = Path.Combine("https://readrixproject.azurewebsites.net/Content/ReaderPicture/");
                        var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                        var filePath = HttpContext.Current.Server.MapPath("~/Content/ReaderPicture/" + fileName);

                        postedFile.SaveAs(filePath);
                        var image = "~/Content/ReaderPicture/" + fileName;
                        return image;
                        // return "File is Uploaded to Path = /Uploads/" + fileName + "Item Name" + item.ItemName;
                    }
                }
            }
            catch (Exception exception)
            {
                return exception.Message + " - Server Error";
            }

            return "No Image Found or Somthing Went Wrong";
        }
    }
}