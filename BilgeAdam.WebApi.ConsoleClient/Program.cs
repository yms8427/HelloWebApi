using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BilgeAdam.WebApi.ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient { BaseAddress = new Uri("https://localhost:5001") };
            while (true)
            {
                var response = await client.GetAsync("api/time/local");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                await Task.Delay(1000);
            }
        }
    }
}
