using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GammaRaySetList.Web
{
    public static class WebApiConfig
    {
        public static string ControllerAndId = "ApiControllerAndIntegerId";

        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: ControllerAndId,
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
