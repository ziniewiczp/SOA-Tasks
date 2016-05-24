using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Library;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // OData code:
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Game>("Games");
            builder.EntitySet<Store>("Stores");
            builder.ComplexType<CardShirt>();

            builder.Function("GetAvailableCardShirts").ReturnsCollection<CardShirt>();

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
