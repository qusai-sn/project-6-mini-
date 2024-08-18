using System.Web;
using System.Web.Optimization;

namespace Fresh_and_FIt
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // jQuery bundle
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // jQuery validation bundle
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Modernizr bundle
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Bootstrap JS bundle
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            // CSS bundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/assets/css/bootstrap.min.css",
                 "~/assets/css/font-awesome.min.css", // Font Awesome
                 "~/assets/css/elegant-icons.css",    // Elegant Icons
                 "~/assets/css/jquery-ui.min.css",
                 "~/assets/css/nice-select.css",
                 "~/assets/css/owl.carousel.min.css",
                 "~/assets/css/slicknav.min.css",
                 "~/assets/css/style.css"));

            // Custom JavaScript bundle for assets
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/assets/js/jquery-3.3.1.min.js",
                      "~/assets/js/bootstrap.min.js",
                      "~/assets/js/jquery-ui.min.js",
                      "~/assets/js/jquery.nice-select.min.js",
                      "~/assets/js/jquery.slicknav.js",
                      "~/assets/js/mixitup.min.js",
                      "~/assets/js/owl.carousel.min.js",
                      "~/assets/js/main.js"));

            // Enable optimizations
            BundleTable.EnableOptimizations = true;
        }
    }
}
