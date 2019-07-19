using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SAT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
<<<<<<< HEAD
                defaults: new { controller = "Carreras", action = "Create", id = UrlParameter.Optional }
=======
                defaults: new { controller = "Empleados", action = "Index", id = UrlParameter.Optional }
>>>>>>> 801e90b4a4134c06c29fc04733fdb1a6bfc5c7c0
            );
        }
    }
}
