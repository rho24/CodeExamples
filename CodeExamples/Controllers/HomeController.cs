using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CodeExamples.Infrastructure;
using CodeExamples.Model;
using CodeExamples.ViewModels;
using Raven.Client;

namespace CodeExamples.Controllers
{
    public class HomeController : RavenControllerBase
    {
        public HomeController(Lazy<IDocumentSession> lazySession) : base(lazySession) {}

        public ActionResult Index() {
            var examples = Session.Query<ExampleDetail>().ToArray();
            return View(Mapper.Map<HomeIndexVM>(examples));
        }
    }
}