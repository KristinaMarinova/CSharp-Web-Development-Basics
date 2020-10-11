using SUS.HTTP;
using System;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.AddRoute("/", HomePage);
            server.AddRoute("/about", About);
            server.AddRoute("/users/login", Login);

            await server.StartAsync(80);
        }

        static HttpResponce HomePage(HttpRequest request)
        {
            throw new System.NotImplementedException();
        }

        static HttpResponce About(HttpRequest request)
        {
            throw new System.NotImplementedException();
        }

        static HttpResponce Login(HttpRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
