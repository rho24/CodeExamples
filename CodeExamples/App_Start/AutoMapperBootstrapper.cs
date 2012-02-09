using System;
using System.Web;
using AutoMapper;
using Autofac;
using Autofac.Features.Indexed;
using CodeExamples.Model;
using CodeExamples.ViewModels;

namespace CodeExamples.App_Start
{
    public static class AutoMapperBootstrapper
    {
        public static void Configure(IContainer container) {
            var markupConverters = container.Resolve<IIndex<Type, IMarkupConverter>>();
            Mapper.CreateMap<IMarkup, IHtmlString>().ConvertUsing(s => markupConverters[s.GetType()].ToHtml(s));

            Mapper.CreateMap<ExampleDetail, ExampleDetailVM>();

            Mapper.AssertConfigurationIsValid();
        }
    }
}