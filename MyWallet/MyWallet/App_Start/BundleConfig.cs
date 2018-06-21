using System.Web;
using System.Web.Optimization;

namespace MyWallet.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Bootstrap core JavaScript
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/vendor/jquery/jquery.min.js",
                "~/vendor/popper/popper.min.js",
                "~/vendor/bootstrap/js/bootstrap.min.js"));

            //Core plugin JavaScript
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/vendor/jquery-easing/jquery.easing.min.js"));

            //Page level scripts for settings
            bundles.Add(new ScriptBundle("~/bundles/settings").Include(
                "~/vendor/settings/Settings.js",
                "~/vendor/settings/jquery-confirm.min.js"));

            //Page level plugin JavaScript for charts
            bundles.Add(new ScriptBundle("~/bundles/charts").Include(
                "~/vendor/chart.js/Chart.min.js"));

            //Page level plugin JavaScript for datatables
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/vendor/datatables/jquery.dataTables.js",
                "~/vendor/datatables/dataTables.bootstrap4.js"));

            //Custom scripts for all pages
            bundles.Add(new ScriptBundle("~/bundles/sb-admin").Include(
                "~/js/sb-admin.min.js"));

            //Custom script for datatables
            bundles.Add(new ScriptBundle("~/bundles/sb-admin-datatables").Include(
                "~/js/sb-admin-datatables.min.js"));

            //Custom script for charts
            bundles.Add(new ScriptBundle("~/bundles/sb-admin-charts").Include(
                "~/js/sb-admin-Barchart.js",
                "~/js/sb-admin-Piechart.js"));

            //Bootstrap core CSS and Custom fonts for this template
            bundles.Add(new StyleBundle("~/content/bootstrap").Include(
                "~/vendor/bootstrap/css/bootstrap.min.css",
                "~/vendor/font-awesome/css/font-awesome.min.css"));

            //Page level styles for settings
            bundles.Add(new StyleBundle("~/contenc/settings").Include(
                "~/vendor/settings/jquery-confirm.min.css"));

            //Page level plugin CSS for Datatables
            bundles.Add(new StyleBundle("~/content/datatables").Include(
                "~/vendor/datatables/dataTables.bootstrap4.css"));

            //Custom styles for this template
            bundles.Add(new StyleBundle("~/content/sb-admin").Include(
                "~/css/sb-admin.css"));
        }
    }
}