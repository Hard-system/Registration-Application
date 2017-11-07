
using System.Web.Mvc;
using System.Web.Routing;

namespace ACCDataStore.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //THis will be default page that runs when you are in .cs format files but if you are in .cshtml format files then they will be run directly and not the default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional }
             ).DataTokens = new RouteValueDictionary(new { area = "Index" });
        }
    }
}

