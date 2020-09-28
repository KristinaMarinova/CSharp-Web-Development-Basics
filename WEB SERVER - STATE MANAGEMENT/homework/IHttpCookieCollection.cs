using System.Collections.Generic;
namespace homework
{
    interface IHttpCookieCollection : IEnumerable<HttpCookie>
    {
        void AddCookie(HttpCookie httpCookie);
        bool ContainsCookie(string key);
        HttpCookie GetCookie(string key);
        bool HasCookies();
    }
}
