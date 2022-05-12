using System.Web;
using System.Web.Optimization;

namespace TestAmazon
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.6.0.min.js"));
            
            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de creación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.min.css").Include("~/Content/TestAmazon.css"));


            bundles.Add(new ScriptBundle("~/bundles/TestAmazon").Include("~/Scripts/TestAmazon.js").Include("~/Scripts/bootstrap.min.js"));
        }
    }
}