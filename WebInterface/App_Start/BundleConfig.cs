using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebInterface.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/styles/semanticui").Include(
                "~/Content/semanticui/semantic.css"
                ));

            bundles.Add(new ScriptBundle("~/scripts/semanticui").Include(
                "~/Content/semanticui/semantic.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/flot").Include(
                "~/Content/flot/jquery.flot.js",
                "~/Content/flot/jquery.flot.time.js",
                "~/Content/flot/jquery.colorhelpers.js"
                ));
        }
    }
}