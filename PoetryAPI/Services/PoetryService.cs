using Microsoft.AspNetCore.Mvc;
using PoetryAPI.Models;
using Newtonsoft.Json.Linq;

namespace PoetryAPI.Services
{
    public class PoetryService
    {
        private readonly HttpClient _httpClient;
        /// <summary />
        public PoetryService(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _httpClient = clientFactory.CreateClient("poetry");
        }

        public async Task<String> GetContentFromTitle(string title)
        {
            string titlePath = "/title/" + title + "/title,author,lines";
            var res = await _httpClient.GetAsync(titlePath);
            var content = await res.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<RawPoem> RawPoemFromTitle(string title)
        {
            string titlePath = "/title/" + title + "/title,author,lines";
            var res = await _httpClient.GetAsync(titlePath);
            var content = await res.Content.ReadAsAsync<JToken>();
            var rawPoem = content.First.ToObject<RawPoem>();
            return rawPoem;
        }
    }
}
