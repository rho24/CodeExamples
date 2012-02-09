﻿using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using CodeExamples.Model;
using MarkdownDeep;
using Raven.Client.Document;

namespace CodeExamples.App_Start
{
    public static class AutoFacBootstrapper
    {
        public static IContainer Start() {
            var builder = new ContainerBuilder();

            RegisterControllers(builder);

            RegisterServices(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        private static void RegisterControllers(ContainerBuilder builder) {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }

        public static void RegisterServices(ContainerBuilder builder) {
            builder.RegisterType<Markdown>();
            builder.RegisterType<TitleCreater>();

            var documentStore = new DocumentStore {ConnectionStringName = "RavenDB"};
            documentStore.Initialize();
            builder.Register(c => documentStore.OpenSession());

            builder.RegisterType<RawHtmlConverter>().Keyed<IMarkupConverter>(typeof (RawMarkUp));
            builder.RegisterType<MarkDownConverter>().Keyed<IMarkupConverter>(typeof (MarkDownMarkUp));
        }
    }
}