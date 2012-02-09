using System.Web.Mvc;
using AutoMapper;
using CodeExamples.Model;
using CodeExamples.ViewModels;

namespace CodeExamples.Controllers
{
    public class ExampleController : Controller
    {
        public ActionResult Detail(string id) {
            var example = new ExampleDetail {
                                                Id = id,
                                                Title = "First example",
                                                Body = new RawMarkUp("<h2>Welcome</h2><p>Some text</p>")
                                            };

            return View(Mapper.Map<ExampleDetailVM>(example));
        }
    }
}