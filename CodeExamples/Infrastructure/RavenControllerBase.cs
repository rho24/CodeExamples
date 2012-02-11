using System;
using System.Web.Mvc;
using Raven.Client;

namespace CodeExamples.Infrastructure
{
    public class RavenControllerBase : Controller
    {
        private readonly Lazy<IDocumentSession> _lazySession;

        public new IDocumentSession Session {
            get { return _lazySession.Value; }
        }

        public RavenControllerBase(Lazy<IDocumentSession> lazySession) {
            _lazySession = lazySession;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext) {
            if (filterContext.Exception == null && _lazySession.IsValueCreated) {
                using (Session)
                    Session.SaveChanges();
            }
            base.OnActionExecuted(filterContext);
        }
    }
}