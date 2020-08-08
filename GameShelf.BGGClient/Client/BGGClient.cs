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
                // FirstName = xElement.Element("firstname").Attribute("value").Value,
                Id = GetRootStringValue(xdoc.Root, "id"),
                Username = username,
                FirstName = GetElementStringValue(xdoc.Root, "firstname", "value"),
                LastName = GetElementStringValue(xdoc.Root, "lastname", "value"),
                Country = GetElementStringValue(xdoc.Root, "country", "value"),
                AvatarLink = GetElementStringValue(xdoc.Root, "avatarlink", "value"),
            };

            return user;
        }

        private static string GetElementStringValue(XElement root, string element, string attribute = null)
        {
            if (root == null) 
                return null;

            if (root.Element(element) == null)
                return null;

            if (attribute == null)
                return null;
            
            return root.Element(element).Attribute(attribute).Value;
        }
        
        private static string GetRootStringValue(XElement root, string attribute = null)
        {
            return root.Attribute(attribute).Value;
        }
        
        private async Task<XDocument> ReadData(Uri requestUrl)
        {
            HttpResponseMessage httpResponse = await GetAsync(requestUrl);
            var responseBody = await httpResponse.Content.ReadAsStringAsync();
            var data = XDocument.Parse(responseBody);
            return data;
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

                    switch (httpResponse.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            break;
                        case HttpStatusCode.Accepted:
                            retries--;
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }

            return httpResponse;
        }
        
        // private string GetStringValue(XElement element, string attribute = null, string defaultValue = "", string d = "")
        // {
        //     if (element == null)
        //         return defaultValue;
        //
        //     if (attribute == null)
        //         return element.Value;
        //
        //     XAttribute xatt = element.Attribute(attribute);
        //     if (xatt == null)
        //         return defaultValue;
        //
        //     return xatt.Value;
        // }
    }
}