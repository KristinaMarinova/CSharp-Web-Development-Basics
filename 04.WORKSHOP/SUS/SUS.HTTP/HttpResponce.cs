using System.Collections.Generic;
namespace SUS.HTTP
{
    public class HttpResponce
    {
        public HttpResponce(HttpStatusCode statusCode, byte[] body)
        {
            this.StatusCode = statusCode;
            this.Body = body;
            this.Header = new List<Header>
            {
                {new Header("Content-Type", "???") },
                {new Header("Content-Length", body.Length.ToString())},
            };
        }
        public HttpStatusCode StatusCode { get; set; }
        public ICollection<Header> Header { get; set; }
        public byte[] Body { get; set; }
    }
}
