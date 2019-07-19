using System.Web;
using System.Web.Optimization;

namespace SAT
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Bootstrap css
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap/css/bootstrap.min.css",
                "~/Content/custom.min.css"));
            //Font Awesome
            bundles.Add(new StyleBundle("~/Content/font-awesome/fonts").Include(
                "~/Content/font-awesome/css/font-awesome.min.css"));


            //DataTables css
            bundles.Add(new StyleBundle("~/content/DataTables").Include(
                "~/content/DataTables/dataTables.bootstrap4.min.css"
                ));
            //jquery
            bundles.Add(new ScriptBundle("~/scripts/jquery").Include(
                "~/scripts/jquery/dist/jquery.min.js",
                "~/Content/bootstrap/js/bootstrap.min.js",
                "~/scripts/bootstrap-progressbar/bootstrap-progressbar.min.js",
                "~/scripts/custom.min.js"));

            //DataTables js
            bundles.Add(new ScriptBundle("~/scripts/DataTables").Include(
                "~/scripts/DataTables/jquery.dataTables.min.js",
                "~/scripts/DataTables/dataTables.bootstrap4.min.js",
                "~/scripts/DataTables.js"));


        }
    }
}