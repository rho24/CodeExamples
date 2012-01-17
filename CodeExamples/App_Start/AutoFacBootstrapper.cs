using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace CodeExamples.App_Start
{
    public static class AutoFacBootstrapper
    {
        public static void Start() {
            var builder = new ContainerBuilder();

            RegisterControllers(builder);

            RegisterServices(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterControllers(ContainerBuilder builder) {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }

        public static void RegisterServices(ContainerBuilder builder) {}
    }
}