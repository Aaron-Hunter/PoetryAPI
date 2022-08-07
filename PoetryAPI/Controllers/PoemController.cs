using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoetryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PoemController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        /// <summary />
        public PoemController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _httpClient = clientFactory.CreateClient("poetry");
        }

        // GET: <PoemController>
        /// <summary>
        /// Generates a random number
        /// </summary>
        /// <returns>A random number</returns>
        [HttpGet("{title}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetTitle(string title)
        {
            string titlePath = "/title/" + title + "/title,author,lines";
            var res = await _httpClient.GetAsync(titlePath);
            var content = await res.Content.ReadAsStringAsync();
            return Ok(content);
        }

        // POST <PoemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT <PoemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE <PoemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
