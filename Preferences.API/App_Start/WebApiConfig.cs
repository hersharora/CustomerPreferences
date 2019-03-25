using System.Web.Http;
using AutoMapper;
using Preferences.API.App_Start;
using Preferences.API.Mappings;

namespace Preferences.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            AutofacConfig.Initialize(config);
            Mapper.Initialize(x =>
            {
                x.AddProfile<CustomerPreferenceMappingProfile>();
            });

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
