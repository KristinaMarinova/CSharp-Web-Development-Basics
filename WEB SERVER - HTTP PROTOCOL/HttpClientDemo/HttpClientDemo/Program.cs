using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
        }

        public async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://softuni.bg/trainings/3164/csharp-web-basics-september-2020";
            HttpClient httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            Console.WriteLine(html);
        }
    }
}
