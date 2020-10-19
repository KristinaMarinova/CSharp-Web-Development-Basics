using SUS.HTTP;
using SUS.MvcFramework;
namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponce Favicon(HttpRequest request)
        {
            return this.File("wwwroot/favicon.ico", "image/vdn.microsoft.icon");
        }
    }
}