using SUS.HTTP;
using SUS.MvcFramework;
namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponce Login(HttpRequest request)
        {
            return View();
        }
        public HttpResponce Register(HttpRequest request)
        {
            return View();
        }
    }
}