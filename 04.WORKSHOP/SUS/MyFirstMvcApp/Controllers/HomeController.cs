using SUS.HTTP;
using SUS.MvcFramework;
namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponce Index(HttpRequest request)
        {
            return View("Views/Home/Index.html");
        }
    }
}