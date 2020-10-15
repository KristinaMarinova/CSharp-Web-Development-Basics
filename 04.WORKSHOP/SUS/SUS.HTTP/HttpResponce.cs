using System.Collections.Generic;
namespace SUS.HTTP
{
    public class HttpResponce
    {
        public HttpResponce(HttpStatusCode statusCode, byte[] body)
        {
            this.StatusCode = statusCode;
            this.Body = body;
            this.Header = new List<Header>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public ICollection<Header> Header { get; set; }
        public byte[] Body { get; set; }
    }
}
