using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public interface IHttpServer
    {
        void AddRoute(string path, Func<HttpRequest, HttpResponse> action);

        void Start(int port);
    }
}
