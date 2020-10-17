using SUS.HTTP;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.AddRoute("/", HomePage);
            server.AddRoute("/favicon.ico", Favicon);
            server.AddRoute("/about", About);
            server.AddRoute("/users/login", Login);

            await server.StartAsync();
        }
        
        static HttpResponce HomePage(HttpRequest request)
        {
            var responseHtml = "<h1>Welcome from Krisi!</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponce("text/html", responseBodyBytes);
            return response;
        }
        private static HttpResponce Favicon(HttpRequest arg)
        {
            var fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponce("image/vdn.microsoft.icon", fileBytes);
            return response;
        }

        static HttpResponce About(HttpRequest request)
        {
            var responseHtml = "<h1>About...</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponce("text/html", responseBodyBytes);
            return response;
        }

        static HttpResponce Login(HttpRequest request)
        {
            var responseHtml = "<h1>Login...</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponce("text/html", responseBodyBytes);
            return response;
        }
    }
}
