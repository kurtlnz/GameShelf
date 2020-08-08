using System.Net.Http;
using System.Threading.Tasks;

namespace GameShelf.BGGClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        
        static async Task Main(string[] args)
        {
            await MainAsync();
        }
        
        private static async Task MainAsync()
        {
            var bggClient = new Client.BGGClient(client);
            var user = await bggClient.GetUser("kurtlnz");
        }
    }
}