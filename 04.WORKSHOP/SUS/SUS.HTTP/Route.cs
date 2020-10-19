using SUS.HTTP;
using System;
namespace SUS.MvcFramework
{
    public class Route
    {
        public Route(string path, Func<HttpRequest, HttpResponce> action)
        {
            this.Path = path;
            this.Action = action;
        }
        public string Path { get; set; }
        public Func<HttpRequest, HttpResponce> Action { get; set; }
    }
}