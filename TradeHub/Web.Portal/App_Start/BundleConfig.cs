using System.Web;
using System.Web.Optimization;

namespace Web.Portal.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles( BundleCollection bundles )
        {
            bundles.Add( new ScriptBundle( "~/bundles/jquery" ).Include(
                        "~/Scripts/jquery-{version}.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/jqueryval" ).Include(
                        "~/Scripts/jquery.validate*" ) );

            //Create a file and uncomment for custom jquery validation
            //bundles.Add( new ScriptBundle( "~/bundles/Validation" ).Include(
            //            "~/Scripts/Validation.js" ) );

            bundles.Add( new StyleBundle( "~/bundles/FoundationStyles" ).Include(
                        "~/Content/foundation.css",
                        "~/Content/foundation-icons.css",
                        "~/Content/app.css" ) );

            bundles.Add( new ScriptBundle( "~/bundles/FoundationScripts" ).Include(
                        "~/Scripts/foundation.js",
                        "~/Scripts/what-input.js",
                        "~/Scripts/app.js" ) );
        }
    }
}