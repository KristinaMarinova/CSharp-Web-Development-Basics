using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponce Favicon(HttpRequest request)
        {
            return this.File("wwwroot/favicon.ico", "image/vdn.microsoft.icon");
        }
        internal HttpResponce BootstrapCss(HttpRequest arg)
        {
            return this.File("wwwroot/css/bootstrap.min.css", "text/css");
        }
        internal HttpResponce CustomCss(HttpRequest arg)
        {
            return this.File("wwwroot/css/custom.css", "text/css");
        }
        internal HttpResponce CustomJs(HttpRequest arg)
        {
            return this.File("wwwroot/js/custom.js", "text/javascript");
        }

        internal HttpResponce BootstrapJs(HttpRequest arg)
        {
            return this.File("wwwroot/js/bootstrap.bundle.min.js", "text/javascript");
        }
    }
}