using System.Web.Mvc;
using System.Web.Routing;
using CodeExamples.App_Start;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof (MvcBootstrapper), "Start")]

namespace CodeExamples.App_Start
{
    public static class MvcBootstrapper
    {
        public static void Start() {
            var container = AutoFacBootstrapper.Start();
            AutoMapperBootstrapper.Configure(container);

            MvcSetup();
        }

        private static void MvcSetup() {
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                "Example", // Route name
                "Example/{action}/{titleUrl}", // URL with parameters
                new {controller = "Example", action = "Detail"} // Parameter defaults
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }
    }
}