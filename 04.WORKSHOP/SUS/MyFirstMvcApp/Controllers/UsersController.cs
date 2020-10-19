using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponce Login(HttpRequest request)
        {
            return View("Views/Users/Login.html");
        }
        public HttpResponce Register(HttpRequest request)
        {
            return View("Views/Users/Register.html");
        }
    }
}