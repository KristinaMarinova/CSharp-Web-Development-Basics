namespace SUS.HTTP
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name, string value) : base(name, value)
        {
        }

        public int MaxAge { get; set; }
        public bool HttpOnly { get; set; }
        public string Path { get; set; }
    }
}
