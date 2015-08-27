using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInterface.Models;

namespace WebInterface.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewBag.Title = "Test";
            return View();
        }

        public ActionResult Test()
        {
            using (var context = new WaterContext())
            {
                var samples = context.Samples.Take(50).ToList();
                return View(samples);
            }
        }
    }
}