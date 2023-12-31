﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
namespace PaieBack
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
            = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute("http://localhost:3000/", "*", "*");
            config.EnableCors(cors);



            // Ajoutez le filtre CorsActionFilter
            //config.Filters.Add(new CorsActionFilter());



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
