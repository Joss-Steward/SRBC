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

        public ActionResult Chart()
        {
            return View();
        }

        public ActionResult ChartData()
        {
            using (var context = new WaterContext())
            {
                var data = context.Stations.Select(s => new
                {
                    label = s.Name,
                    data = s.Samples.Take(50).Select(d => new
                    {
                        time = d.DateTime,
                        oxy = d.Oxygen
                    })
                }).ToList();

                /* Time in JavaScript is stored as milliseconds ellapsed since the Unix epoch */
                var epochTicks = new DateTime(1970, 1, 1).Ticks;

                var json = data.Select(s => new
                {
                    label = s.label,
                    data = s.data.Select(p => new double[]{
                        ((p.time.Ticks - epochTicks) / TimeSpan.TicksPerMillisecond),
                        (double)p.oxy
                    })
                });

                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }
    }
}