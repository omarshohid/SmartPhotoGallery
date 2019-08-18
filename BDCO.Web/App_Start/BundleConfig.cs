using System.Web;
using System.Web.Optimization;

namespace BDCO.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-2.1.3.js",
                       "~/Scripts/KendoUI/kendo.all.min.js",
                       "~/Scripts/KendoUI/kendo.aspnetmvc.min.js",
                       "~/Scripts/KendoUI/kendo.web.min.js",
                       "~/Scripts/bootstrap.min.js",
                       "~/Scripts/jquery.smartmenus.js",
                       "~/Scripts/jquery.smartmenus.bootstrap.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/NavigationBar.css",
                      "~/Content/KendoUI/kendo.common.min.css",
                      "~/Content/KendoUI/kendo.metro.min.css",
                      "~/Content/BootstrapMenu.css",
                      "~/Content/jquery.smartmenus.bootstrap.css",
                       "~/Content/AppStyle.css"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/suchana").Include(
                     "~/Scripts/jquery-2.1.3.min.js",
                     "~/Scripts/Appetizer.js",
                     "~/Scripts/iziModal.js",
                     "~/Scripts/sweetalert.min.js",
                     "~/Scripts/bootstrap.min.js",
                     "~/Scripts/jquery.smartmenus.js",
                     "~/Scripts/jquery.smartmenus.bootstrap.js",
                     "~/Scripts/KendoUI/kendo.web.min.js"
                     ));
            bundles.IgnoreList.Clear();
        }
    }
}
