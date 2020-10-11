using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private const int BufferSize = 4096;
        private const string NewLine = "\r\n";
        IDictionary<string, Func<HttpRequest, HttpResponce>> routeTable = new Dictionary<string, Func<HttpRequest, HttpResponce>>();
        public void AddRoute(string path, System.Func<HttpRequest, HttpResponce> action)
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

        public async Task StartAsync(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();
            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            using (NetworkStream stream = tcpClient.GetStream())
            {
                List<byte> data = new List<byte>();

                int position = 0;

                byte[] buffer = new byte[BufferSize];

                while (true)
                {
                    int count = await stream.ReadAsync(buffer, position, buffer.Length);

                    position += count;

                    if (count < buffer.Length)
                    {
                        var partialBuffer = new byte[count];
                        Array.Copy(buffer, partialBuffer, count);
                        data.AddRange(partialBuffer);
                        break;

                    }
                    else
                    {
                        data.AddRange(buffer);
                    }
                }

                var requestAsString = Encoding.UTF8.GetString(data.ToArray());

                Console.WriteLine(requestAsString);

                var responseHtml = "<h1>Welcome from Krisi!</h1>";
                var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

                var httpResponse = "HTTP/1.1 200 OK" + NewLine +
                    "Server: SUS Server 1.0" + NewLine +
                    "Contwnt-Type: text/html" + NewLine +
                    "Content-Length: " + responseBodyBytes.Length + NewLine
                    + NewLine;

                var responseHeaderBytes = Encoding.UTF8.GetBytes(httpResponse);

                await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
                await stream.WriteAsync(responseBodyBytes, 0, responseBodyBytes.Length);
            }

            tcpClient.Close();  
        }
    }
}
