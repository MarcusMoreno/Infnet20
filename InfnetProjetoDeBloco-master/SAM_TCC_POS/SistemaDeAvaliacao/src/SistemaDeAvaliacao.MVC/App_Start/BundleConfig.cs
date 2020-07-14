using System.Web.Optimization;

namespace SistemaDeAvaliacao.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //AdminLTE template
            bundles.Add(new ScriptBundle("~/bundles/AdmLte").Include(
                        "~/Scripts/AdmLte/adminlte.js",
                        "~/Scripts/Bootstrap/bootstrap.js",
                        "~/Scripts/Bootstrap/npm.js",
                        "~/Scripts/jquery/jquery.js",
                        "~/Scripts/jquery/core.js",
                        "~/Scripts/jquery/jquery.slim.js"));

            bundles.Add(new StyleBundle("~/Content/AdmLte").Include(
                      "~/Content/Bootstrap/bootstrap.css",
                      //"~/Content/Bootstrap/bootstrap-theme.css",
                      "~/Content/AdmLte/alt/AdminLTE-bootstrap-social.css",
                      "~/Content/AdmLte/alt/AdminLTE-fullcalendar.css",
                      "~/Content/AdmLte/alt/AdminLTE-select2.css",
                      "~/Content/AdmLte/alt/AdminLTE-without-plugins.css",
                      "~/Content/font-awesome/font-awesome.css",
                      "~/Content/AdmLte/AdminLTE.css",
                      "~/Content/AdmLte/skins/skin-blue.css"));
            //AdminLTE template fim //

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

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
        }
    }
}
