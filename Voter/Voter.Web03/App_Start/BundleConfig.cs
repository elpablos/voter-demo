using System.Web;
using System.Web.Optimization;

namespace Voter.Web
{
    /// <summary>
    /// Konfigurace balíčků - web
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registrace balíčků s JS a CSS
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/Scripts/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/Plugins/bootstrap-datepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/pace").Include(
                        "~/Scripts/Plugins/pace.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/Plugins/jquery.dataTables.min.js",
                        "~/Scripts/Plugins/dataTables.bootstrap.min.js",
                        "~/Scripts/Plugins/dataTables.responsive.min.js",
                        "~/Scripts/dataTables.init.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/Scripts/Plugins/select2.min.js",
                        "~/Scripts/main.js",
                         "~/Scripts/main-ex.js"
                         ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/main.css",
                      "~/Content/main-ex.css"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      "~/Content/Plugins/responsive.dataTables.min.css"
                      ));

            // povoleno - pouziti minifikovanych verzi js!
            BundleTable.EnableOptimizations = true;
        }
    }
}