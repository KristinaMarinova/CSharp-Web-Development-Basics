using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        IDictionary<string, Func<HttpRequest, HttpResponse>> routeTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();
        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(path))
            {
                routeTable[path] = action;
            }
            else
            {
                routeTable.Add(path, action);
            }
        }

        public void Start(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
        }
    }
}
