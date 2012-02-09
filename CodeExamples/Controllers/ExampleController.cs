using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CodeExamples.Model;
using CodeExamples.ViewModels;
using Raven.Client;

namespace CodeExamples.Controllers
{
    public class ExampleController : Controller
    {
        private readonly Lazy<IDocumentSession> _session;

        public ExampleController(Lazy<IDocumentSession> session) {
            _session = session;
        }

        public ActionResult Detail(string id) {
            using (var session = _session.Value) {
                var detail = session.Query<ExampleDetail>().SingleOrDefault(d => d.Id == id);

                if (detail == null)
                    return HttpNotFound("Could not find example");

                return View(Mapper.Map<ExampleDetailVM>(detail));
            }
        }

        public ActionResult Create() {
            return View("Edit", new ExampleDetailEM());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ExampleDetailEM editModel) {
            using (var session = _session.Value) {
                var detail = Mapper.Map<ExampleDetail>(editModel);

                if (!ModelState.IsValid)
                    return View("Edit");

                session.Store(detail);
                session.SaveChanges();

                return RedirectToAction("Detail", new {id = detail.Id});
            }
        }

        public ActionResult Edit(string id) {
            using (var session = _session.Value) {
                var detail = session.Query<ExampleDetail>().SingleOrDefault(d => d.Id == id);

                if (detail == null)
                    return HttpNotFound("Could not find example");

                return View(Mapper.Map<ExampleDetailEM>(detail));
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(string id, ExampleDetailEM editModel) {
            using (var session = _session.Value) {
                var detail = session.Query<ExampleDetail>().SingleOrDefault(d => d.Id == id);

                Mapper.Map(editModel, detail);

                if (!ModelState.IsValid)
                    return View("Edit");

                session.Store(detail);
                session.SaveChanges();

                return RedirectToAction("Detail", new {id = detail.Id});
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(string id) {
            using (var session = _session.Value) {
                var detail = session.Query<ExampleDetail>().SingleOrDefault(d => d.Id == id);

                session.Delete(detail);
                session.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }
    }
}