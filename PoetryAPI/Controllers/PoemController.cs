using Microsoft.AspNetCore.Mvc;
using PoetryAPI.Services;
using PoetryAPI.Models;

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
        /// Gets the title, author and lines of all poems matching the given title
        /// </summary>
        /// <returns>A string containing title, author, and lines of matching poems</returns>
        [HttpGet("{title}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetByTitle(string title)
        {
            string titlePath = "/title/" + title + "/title,author,lines";
            var res = await _httpClient.GetAsync(titlePath);
            var content = await res.Content.ReadAsStringAsync();
            return Ok(content);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<Poem>> GetAll() => PoemService.GetAll();

        // POST <PoemController>
        [HttpPost]
        public IActionResult Create(Poem poem)
        {
            PoemService.Add(poem);
            return CreatedAtAction(nameof(Create), new { id = poem.Id }, poem);
        }

        // PUT <PoemController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Poem poem)
        {
            if (id != poem.Id)
                return BadRequest();

            var existingPoem = PoemService.Get(id);
            if (existingPoem is null)
                return NotFound();

            PoemService.Update(poem);

            return NoContent();
        }

        // DELETE <PoemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var poem = PoemService.Get(id);

            if (poem is null)
                return NotFound();

            PoemService.Delete(id);

            return NoContent();
        }
    }
}
