using SUS.HTTP;
using System.IO;
using System.Text;
namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponce View(string viewPath)
        {
            var responseHtml = System.IO.File.ReadAllText(viewPath);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponce("text/html", responseBodyBytes);
            return response;
        }

        public HttpResponce File(string filePath, string contentType)
        {
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponce(contentType, fileBytes);
            return response;
        }
    }
}