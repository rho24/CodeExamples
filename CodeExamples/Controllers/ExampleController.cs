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
                                                Body =
                                                    new MarkDownMarkUp {Markdown = @"## Welcome to MarkdownDeep

This demo page lets you try the JavaScript version of MarkdownDeep in your browser."}
                                            };

            return View(Mapper.Map<ExampleDetailVM>(example));
        }
    }
}