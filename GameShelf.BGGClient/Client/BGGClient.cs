using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GameShelf.BGGClient.Models;

namespace GameShelf.BGGClient.Client
{
    public class BGGClient
    {
        private const string BGG_XML_API2_URL = "https://www.boardgamegeek.com/xmlapi2";
        
        private readonly HttpClient _httpClient;
        
        public BGGClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<User> GetUser(string username)
        {
            var requestUri = new Uri(BGG_XML_API2_URL + $"/user?name={username}");
            var xdoc = await ReadData(requestUri);
            
            var user = new User()
            {
                Id = GetStringValue(xdoc.Root, "id"),
                Username = GetStringValue(xdoc.Root, "name"),
                FirstName = GetStringValue(xdoc.Root, "firstname", "value"),
                LastName = GetStringValue(xdoc.Root, "lastname", "value"),
                Country = GetStringValue(xdoc.Root, "country", "value"),
                AvatarLink = GetStringValue(xdoc.Root, "avatarlink", "value"),
            };

            return user;
        }

        private static string GetStringValue(XElement root, string element, string attribute = null)
        {
            if (root == null) 
                return null;

            if (root.Element(element) == null)
                return null;

            if (attribute == null)
                return null;
            
            return root.Element(element).Attribute(attribute).Value;
        }
        
        private static string GetStringValue(XElement root, string attribute = null)
        {
            return root.Attribute(attribute).Value;
        }
        
        private async Task<XDocument> ReadData(Uri requestUrl)
        {
            var content = await GetXmlContentAsync(requestUrl);
            var doc = XDocument.Parse(content);
            
            return doc;
        }

        private async Task<string> GetXmlContentAsync(Uri requestUrl)
        {
            var httpResponse = await GetAsync(requestUrl);
            var content = await httpResponse.Content.ReadAsStringAsync();
            
            return content;
        }

        private async Task<HttpResponseMessage> GetAsync(Uri requestUrl)
        {
            var httpResponse = new HttpResponseMessage();
            var retries = 5;
            for (var i = 0; i < retries; i++)
            {
                try
                {
                    httpResponse = await _httpClient.GetAsync(requestUrl);

                    if (httpResponse.StatusCode == HttpStatusCode.Accepted)
                    {
                        retries--;
                        await Task.Delay(5000);
                        continue;
                    }
                    
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }

            return httpResponse;
        }
    }
}