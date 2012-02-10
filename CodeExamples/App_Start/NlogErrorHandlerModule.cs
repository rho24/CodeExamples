using System;
using System.Web;
using CodeExamples.App_Start;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using NLog;

[assembly: PreApplicationStartMethod(typeof (NlogErrorHandlerModule), "Start")]
namespace CodeExamples.App_Start
{
    public class NlogErrorHandlerModule : IHttpModule
    {
        public static void Start() {
            DynamicModuleUtility.RegisterModule(typeof(NlogErrorHandlerModule));
        }

        private HttpApplication _context;

        public void Init(HttpApplication context) {
            _context = context;
            _context.Error += OnContextError;
        }

        public void Dispose() {
        }

        private void OnContextError(object sender, EventArgs e) {
            if (_context.Context.Error != null) {
                var logger = LogManager.GetLogger("Application");

                logger.Error("Application Error:{0}", _context.Context.Error);
            }
        }
    }
}