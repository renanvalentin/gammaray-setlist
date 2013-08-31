using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GammaRaySetList.Web.App_Start
{
    public static class GlobalConfig
    {
        public static void CustomizeConfig(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
           
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; 
        }
    }
}