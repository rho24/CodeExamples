using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CodeExamples.Model;
using CodeExamples.ViewModels;
using Raven.Client;

namespace CodeExamples.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lazy<IDocumentSession> _session;

        public HomeController(Lazy<IDocumentSession> session) {
            _session = session;
        }

        public ActionResult Index() {
            using (var session = _session.Value) {
                var examples = session.Query<ExampleDetail>().ToArray();
                return View(Mapper.Map<HomeIndexVM>(examples));
            }
        }
    }
}