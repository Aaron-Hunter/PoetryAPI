using Microsoft.AspNetCore.Mvc;
using PoetryAPI.Models;
using Newtonsoft.Json.Linq;

namespace PoetryAPI.Services
{
    public class PoetryService
    {
        private readonly IHttpClientFactory _httpFactory;
        /// <summary />
        public PoetryService(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _httpFactory = clientFactory;//.CreateClient("poetry");
        }

        public async Task<String> GetContentFromTitle(string url, string title)
        {
            using (HttpClient httpClient = _httpFactory.CreateClient())
            using (HttpResponseMessage response = await httpClient.GetAsync(url + "/title/" + title + "/title,author,lines"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                }
            }
            return "";
        }

        public async Task<RawPoem> RawPoemFromTitle(string url, string title)
        {
            using (HttpClient httpClient = _httpFactory.CreateClient())
            using (HttpResponseMessage response = await httpClient.GetAsync(url + "/title/" + title + "/title,author,lines"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsAsync<JToken>();
                    var rawPoem = content.First.ToObject<RawPoem>();
                    return rawPoem;
                }
            }
            return null;
        }
    }
}
