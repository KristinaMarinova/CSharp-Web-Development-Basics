using SUS.HTTP;
using SUS.MvcFramework;
namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponce Add(HttpRequest request)
        {
            return View("Add");
        }
        public HttpResponce All(HttpRequest request)
        {
            return View("All");
        }
        public HttpResponce Collection(HttpRequest request)
        {
            return View("Collection");
        }
    }
}