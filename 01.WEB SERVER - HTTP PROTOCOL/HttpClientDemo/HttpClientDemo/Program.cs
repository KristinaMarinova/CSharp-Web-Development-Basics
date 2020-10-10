using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await ReadData();
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://softuni.bg/trainings/3164/csharp-web-basics-september-2020";
            HttpClient httpClient = new HttpClient();

            var responce = await httpClient.GetAsync(url);
            Console.WriteLine(responce.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine, responce.Headers.Select(x=>x.Key + ": " + x.Value.First())));
        }
    }
}
