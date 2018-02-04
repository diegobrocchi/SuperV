using System.Web;
using System.Web.Optimization;

namespace SuperV
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.signalR-2.2.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                       "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-3.4.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/require").Include(
                "~/Scripts/require.js"));


            bundles.Add(new ScriptBundle("~/bundles/ace").Include(
                "~/Scripts/ace-build/ace.js"));

            bundles.Add(new ScriptBundle("~/bundles/ace-ext").Include(
                "~/Scripts/ace-build/ext-language_tools.js",
                "~/Scripts/ace-build/theme-ambiance.js",
                "~/Scripts/ace-build/theme-dreamweaver.js"));

            bundles.Add(new ScriptBundle("~/bundles/dx_all").Include(
                "~/Scripts/dx.all.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add((new ScriptBundle("~/bundles/cldr").Include(
                "~/Scripts/cldr.js",
                "~/Scripts/cldr/event.js",
                "~/Scripts/cldr/supplemental.js",
                "~/Scripts/cldr/unresolved.js")));

            bundles.Add(new ScriptBundle("~/bundles/globalize").Include(
                "~/Scripts/globalize.js",
                "~/Scripts/globalize/currency.js",
                "~/Scripts/globalize/date.js",
                "~/Scripts/globalize/message.js",
                "~/Scripts/globalize/number.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/jquery.bootstrap-autohidingnavbar.js",
                      "~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                "~/Scripts/signalR_loader.js",
                "~/Scripts/signalR_functions.js"));

            bundles.Add(new ScriptBundle("~/bundles/panel").Include(
                       "~/Scripts/panel.js"));

            bundles.Add(new StyleBundle("~/bundles/dx_cl").Include(
                "~/Content/dx.common.css",
                "~/Content/dx.light.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/sb-admin.css",
                      "~/Content/font-awesome.css",
                      "~/Content/site.css"));
        }
    }
}
