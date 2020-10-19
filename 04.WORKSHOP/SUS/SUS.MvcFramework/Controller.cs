using SUS.HTTP;
using System.IO;
using System.Text;
namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponce View(string viewPath)
        {
            var responseHtml = File.ReadAllText(viewPath);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponce("text/html", responseBodyBytes);
            return response;
        }
    }
}