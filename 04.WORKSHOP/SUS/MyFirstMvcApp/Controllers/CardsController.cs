using SUS.HTTP;
using SUS.MvcFramework;
namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponce Add(HttpRequest request)
        {
            return View("Views/Cards/Add.html");
        }
        public HttpResponce All(HttpRequest request)
        {
            return View("Views/Cards/All.html");
        }
        public HttpResponce Collection(HttpRequest request)
        {
            return View("Views/Cards/Collection.html");
        }
    }
}