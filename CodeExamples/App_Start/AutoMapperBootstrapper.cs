using System;
using System.Web;
using AutoMapper;
using Autofac;
using Autofac.Features.Indexed;
using CodeExamples.Infrastructure;
using CodeExamples.Model;
using CodeExamples.ViewModels;

namespace CodeExamples.App_Start
{
    public static class AutoMapperBootstrapper
    {
        public static void Configure(IContainer container) {
            Mapper.CreateMap<ExampleDetail[], HomeIndexVM>()
                .ForMember(dest => dest.Examples, opt => opt.MapFrom(src => src));

            Mapper.CreateMap<ExampleDetail, HomeIndexVM.Example>();

            var markupConverters = container.Resolve<IIndex<Type, IMarkupConverter>>();
            Mapper.CreateMap<IMarkup, IHtmlString>().ConvertUsing(s => markupConverters[s.GetType()].ToHtml(s));

            Mapper.CreateMap<ExampleDetail, ExampleDetailVM>();
            Mapper.CreateMap<ExampleDetail, ExampleDetailEM>()
                .ForMember(dest => dest.Markdown, opt => opt.MapFrom(src => ((MarkDownMarkUp) src.Body).Markdown));

            var creator = container.Resolve<TitleCreator>();
            Mapper.CreateMap<ExampleDetailEM, ExampleDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TitleUrl, opt => opt.MapFrom(src => creator.CreateFromTitle(src.Title)))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => new MarkDownMarkUp {Markdown = src.Markdown}))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            Mapper.AssertConfigurationIsValid();
        }
    }
}