namespace SUS.HTTP
{
    public class Cookie
    {
        private string cookiesAsString;

        public Cookie(string cookiesAsString)
        {
            this.cookiesAsString = cookiesAsString;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}