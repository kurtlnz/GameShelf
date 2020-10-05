using System;
using System.Threading.Tasks;

namespace GameShelf.BGGClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await MainAsync();
        }
        
        private static async Task MainAsync()
        {
            var client = new Client.BGGClient();
            
            // Get User
            // await client.GetUserAsync("kurtlnz");
            
            // Search 
            var searchResult = await client.SearchAsync("splendor");
            foreach (var item in searchResult.Items)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}