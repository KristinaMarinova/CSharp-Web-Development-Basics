using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
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
            try
            {
                using (NetworkStream stream = tcpClient.GetStream())
                {
                    List<byte> data = new List<byte>();

                    int position = 0;

                    byte[] buffer = new byte[HttpConstants.BufferSize];

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

                    var request = new HttpRequest(requestAsString);
                    Console.WriteLine($"{request.Method} {request.Path} => {request.Headers.Count} headers");

                    var responseHtml = "<h1>Welcome from Krisi!</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
                    var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

                    var httpResponse = "HTTP/1.1 200 OK" + HttpConstants.NewLine +
                        "Server: SUS Server 1.0" + HttpConstants.NewLine +
                        "Contwnt-Type: text/html" + HttpConstants.NewLine +
                        "Content-Length: " + responseBodyBytes.Length + HttpConstants.NewLine
                        + HttpConstants.NewLine;

                    var responseHeaderBytes = Encoding.UTF8.GetBytes(httpResponse);

                    await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
                    await stream.WriteAsync(responseBodyBytes, 0, responseBodyBytes.Length);
                }
                tcpClient.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
