using System.Collections.Generic;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestString)
        {
            var lines = requestString.Split(new string[] { HttpConstants.NewLine }, System.StringSplitOptions.None);
            var hederLine = lines[0];
            var hederLineParts = hederLine.Split(' ');
            this.Method = hederLineParts[0];
            this.Path = hederLineParts[1];

            int lineIndex = 1;
            bool isInHeaders = true;

            while (lineIndex < lines.Length)
            {
                var line = lines[lineIndex];
                lineIndex++;

                if (isInHeaders)
                {

                }
                else
                {

                }

                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeaders = false;
                    break;
                }
            }
        }

        public string Path { get; set; }
        public string Method { get; set; }
        public List<Header> Headers { get; set; }
        public List<Cookie> Cookies { get; set; }
        public string Body { get; set; }
    }
}
