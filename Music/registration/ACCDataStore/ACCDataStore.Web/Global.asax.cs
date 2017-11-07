using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http; //<<--this was added for global config line 21
using System.Web.Mvc;
using System.Web.Optimization; //<<--this was added
using System.Web.Routing;

namespace ACCDataStore.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bootstrapper.Run();
            //follow this link and you will trace all changes added remove 5 put s
            /**http5://blogs.msdn.microsoft.com/rickandy/2012/03/23/securing-your-asp-net-mvc-4-app-and-the-new-allowanonymous-attribute/ */
            //below line 21 globalconfig code was added jun2017 for protecting pages from accessing them in url
            //GlobalConfiguration.Configuration.Filters.Add(new System.Web.Http.AuthorizeAttribute());
        }
    }
}
