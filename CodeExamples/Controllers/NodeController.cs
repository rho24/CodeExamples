using System;
using System.Linq;
using System.Web.Mvc;
using CodeExamples.Infrastructure;
using CodeExamples.Model;
using Raven.Client;

namespace CodeExamples.Controllers
{
    public class NodeController : RavenControllerBase
    {
        public NodeController(Lazy<IDocumentSession> lazySession) : base(lazySession) {}

        public ActionResult Index() {
            return View();
        }

        public ActionResult Nodes() {
            var nodes = Session.Query<NodeWithId>("NodeWithId").ToArray();

            return Json(nodes, JsonRequestBehavior.AllowGet);
        }
    }
}