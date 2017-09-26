using System.Web;
using System.Web.Optimization;

namespace TalentConnect
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/base")
                .Include("~/scripts/jquery-2.1.3.min.js")
                .Include("~/scripts/custom.js")
                .Include("~/scripts/jquery.superfish.js")
                .Include("~/scripts/jquery.themepunch.tools.min.js")
                .Include("~/scripts/jquery.themepunch.revolution.min.js")
                .Include("~/scripts/jquery.themepunch.showbizpro.min.js")
                .Include("~/scripts/jquery.flexslider-min.js")
                .Include("~/scripts/chosen.jquery.min.js")
                .Include("~/scripts/jquery.magnific-popup.min.js")
                .Include("~/scripts/waypoints.min.js")
                .Include("~/scripts/jquery.counterup.min.js")
                .Include("~/scripts/jquery.jpanelmenu.js")
                .Include("~/scripts/stacktable.js")
                .Include("~/scripts/headroom.min.js"));

            bundles.Add(new StyleBundle("~/content/css")
                .Include("~/content/style.css")
                .Include("~/content/colors/green.css"));
        }
    }
}