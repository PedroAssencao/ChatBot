using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Chatbot.Infrastructure.Meta.Repository.Interfaces;
using Newtonsoft.Json;
namespace Chatbot.Infrastructure.Meta.Repository
{
    internal class MetaRepository : IMetaClient
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public HttpClient ConfigurarClient(string token, string url)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Other");
            _httpClient.BaseAddress = new Uri(url);
            return _httpClient;
        }



        public async Task<string> PostAsync(string url, string token, dynamic data)
        {
            var client = ConfigurarClient(token, url);
            var response = await client.PostAsync(client.BaseAddress, data);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }




    }
}
