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
    public class ExampleController : RavenControllerBase
    {
        public ExampleController(Lazy<IDocumentSession> lazySession) : base(lazySession) {}

        public ActionResult Detail(string titleUrl) {
            var detail = Session.Query<ExampleDetail>().SingleOrDefault(d => d.TitleUrl == titleUrl);

            if (detail == null)
                return HttpNotFound("Could not find example");

            return View(Mapper.Map<ExampleDetailVM>(detail));
        }

        public ActionResult Create() {
            return View("Edit", new ExampleDetailEM());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ExampleDetailEM editModel) {
            if (!ModelState.IsValid)
                return View("Edit");

            var detail = Mapper.Map<ExampleDetail>(editModel);

            Session.Store(detail);
            Session.SaveChanges();

            return RedirectToAction("Detail", new {id = detail.TitleUrl});
        }

        public ActionResult Edit(string titleUrl) {
            var detail = Session.Query<ExampleDetail>().SingleOrDefault(d => d.TitleUrl == titleUrl);

            if (detail == null)
                return HttpNotFound("Could not find example");

            return View(Mapper.Map<ExampleDetailEM>(detail));
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(string titleUrl, ExampleDetailEM editModel) {
            if (!ModelState.IsValid)
                return View("Edit");

            var detail = Session.Query<ExampleDetail>().SingleOrDefault(d => d.TitleUrl == titleUrl);

            Mapper.Map(editModel, detail);


            Session.SaveChanges();

            return RedirectToAction("Detail", new {id = detail.TitleUrl});
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(string titleUrl) {
            var detail = Session.Query<ExampleDetail>().SingleOrDefault(d => d.TitleUrl == titleUrl);

            Session.Delete(detail);
            Session.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}