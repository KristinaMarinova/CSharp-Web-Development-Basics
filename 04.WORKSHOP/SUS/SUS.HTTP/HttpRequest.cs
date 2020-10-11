using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();

            var lines = requestString.Split(new string[] { HttpConstants.NewLine }, System.StringSplitOptions.None);
            var hederLine = lines[0];
            var hederLineParts = hederLine.Split(' ');
            this.Method = hederLineParts[0];
            this.Path = hederLineParts[1];

            int lineIndex = 1;
            bool isInHeaders = true;
            StringBuilder bodyBuilder = new StringBuilder();

            while (lineIndex < lines.Length)
            {
                var line = lines[lineIndex];
                lineIndex++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeaders = false;
                    continue;
                }
                if (isInHeaders)
                {
                    this.Headers.Add(new Header(line));
                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }
            }

            this.Body = bodyBuilder.ToString();

        }

        public string Path { get; set; }
        public string Method { get; set; }
        public List<Header> Headers { get; set; }
        public List<Cookie> Cookies { get; set; }
        public string Body { get; set; }
    }
}
