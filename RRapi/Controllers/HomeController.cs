using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RRapi.Models;

namespace RRapi.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        //public ActionResult Index()
        //{
        //    //List<tbladmin> tbladmins = new List<tbladmin>();
        //    //var a=db.tbladmins.ToList();    
        //    return View();
        //}
        //public JsonResult getall()
        //{
        //    var readers = db.Readers.ToList();
        //    var json = JsonConvert.SerializeObject(readers);
        //    return Json(json, JsonRequestBehavior.AllowGet);
        //}
    }
}
