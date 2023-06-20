using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaieBack.Models
{
    public class CorsModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += HandlePreflightRequest;
            context.EndRequest += AddCorsHeaders;
        }

        private void HandlePreflightRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            var context = app.Context;

            if (context.Request.HttpMethod == "OPTIONS")
            {
                context.Response.StatusCode = 200;
                context.Response.End();
            }
        }

        private void AddCorsHeaders(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            var context = app.Context;

            context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:3000");
            context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
            context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Authorization");
        }

        public void Dispose()
        {
        }
    }
}