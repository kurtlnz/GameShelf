using System;
using System.Collections.Generic;
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
        private const string BGG_XML_API2_URL = "https://www.boardgamegeek.com/xmlapi2/";
        
        private readonly HttpClient _httpClient;
        
        public BGGClient()
        {
            _httpClient = new HttpClient();
        }
        
        public async Task<User> GetUserAsync(string username)
        {
            var uri = new Uri(BGG_XML_API2_URL + $"user?name={username}");
            
            var data = await ReadData(uri);
            
            return new User
            {
                Id = GetStringValue(data.Root, "id"),
                Username = GetStringValue(data.Root, "name"),
                FirstName = GetStringValue(data.Root, "firstname", "value"),
                LastName = GetStringValue(data.Root, "lastname", "value"),
                Country = GetStringValue(data.Root, "country", "value"),
                AvatarLink = GetStringValue(data.Root, "avatarlink", "value"),
            };
        }
        
        public async Task<SearchResult> SearchAsync(string value)
        {
            var uri = new Uri(BGG_XML_API2_URL + $"search?query={value}");
            
            var data = await ReadData(uri);

            var items = new List<SearchItem>();
            
            return new SearchResult();
        }
        
        // public async Task<Collection> GetCollection(string username)
        // {
        //     var uri = new Uri(BGG_XML_API2_URL + $"collection?username={username}");
        //     var data = await ReadData(uri);
        //
        //     var collection = new List<Thing>();
        //     
        //     var  = new Collection()
        //     {
        //         Id = GetStringValue(data.Root, "id"),
        //         Username = GetStringValue(data.Root, "name"),
        //         FirstName = GetStringValue(data.Root, "firstname", "value"),
        //         LastName = GetStringValue(data.Root, "lastname", "value"),
        //         Country = GetStringValue(data.Root, "country", "value"),
        //         AvatarLink = GetStringValue(data.Root, "avatarlink", "value"),
        //     };
        //
        //     return collection;
        // }

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
            
            try
            {
                var retries = 5;
                for (var i = 0; i < retries; i++)
                {
                    httpResponse = await _httpClient.GetAsync(requestUrl);

                    if (httpResponse.StatusCode == HttpStatusCode.Accepted)
                    {
                        await Task.Delay(5000);
                        continue;
                    }
                    
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            
            return httpResponse;
        }
    }
}