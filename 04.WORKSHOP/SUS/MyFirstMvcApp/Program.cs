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
            server.AddRoute("/favicon.ico", Favicon);
            server.AddRoute("/about", About);
            server.AddRoute("/users/login", Login);

            await server.StartAsync();
        }


        static HttpResponce HomePage(HttpRequest request)
        {
            throw new System.NotImplementedException();
        }
        private static HttpResponce Favicon(HttpRequest arg)
        {
            throw new NotImplementedException();
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
