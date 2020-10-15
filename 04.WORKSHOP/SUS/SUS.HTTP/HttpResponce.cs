using System.Collections.Generic;
namespace SUS.HTTP
{
    public class HttpResponce
    {
        public HttpStatusCode StatusCode { get; set; }
        public ICollection<Header> MyProperty { get; set; }
        public byte[] Body { get; set; }
    }
}
