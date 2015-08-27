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
                "~/Content/semantic.css"
                ));

            bundles.Add(new ScriptBundle("~/scripts/semanticui").Include(
                "~/Content/semantic.js"
                ));
        }
    }
}