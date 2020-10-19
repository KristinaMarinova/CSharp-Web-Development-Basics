﻿using SUS.HTTP;
using System.Runtime.CompilerServices;
using System.Text;
namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponce View([CallerMemberName]string viewPath = null)
        {
            var responseHtml = System.IO.File.ReadAllText("Views/" + this.GetType().Name.Replace("Controller", string.Empty) + "/" + viewPath + ".html");
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