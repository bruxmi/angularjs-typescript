﻿using System.Web;
using System.Web.Optimization;

namespace WebApiTypeScript
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-animate.js",
                    "~/Scripts/angular-cookies.js",
                    "~/Scripts/angular-route.js",
                    "~/Scripts/angular-sanitize.js",
                    "~/Scripts/angular-ui-router.js",
                    "~/Scripts/ui-grid.js",
                    "~/Scripts/angular-resource.js",
                    "~/Scripts/ui-bootstrap.js",
                    "~/Scripts/ui-bootstrap-tpls.js",
                    "~/Scripts/moment.js",
                    "~/Scripts/moment-with-locales.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularServices").IncludeDirectory(
                    "~/Angular", "*.js", true));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/ui-grid.css"));
        }
    }
}
