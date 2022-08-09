using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PoetryAPI.Services;
using PoetryAPI.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoetryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PoemController : ControllerBase
    {
        private PoetryService _poetryService;
        /// <summary />
        public PoemController(IHttpClientFactory clientFactory)
        {
            _poetryService = new PoetryService(clientFactory);
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
            var content = _poetryService.GetContentFromTitle(title);
            return Ok(content.Result);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<Poem>> GetAll() => PoemDataService.GetAll();

        // POST <PoemController>

        [HttpPost("{title}")]
        public async Task<IActionResult> CreateByTitle(string title)
        {
            var rawPoem = _poetryService.RawPoemFromTitle(title).Result;
            PoemDataService.Add(rawPoem);
            return CreatedAtAction(nameof(CreateByTitle), new { title = rawPoem.Title}, rawPoem);
        }

        // PUT <PoemController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Poem poem)
        {
            if (id != poem.Id)
                return BadRequest();

            var existingPoem = PoemDataService.Get(id);
            if (existingPoem is null)
                return NotFound();

            PoemDataService.Update(poem);

            return NoContent();
        }

        // DELETE <PoemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var poem = PoemDataService.Get(id);

            if (poem is null)
                return NotFound();

            PoemDataService.Delete(id);

            return NoContent();
        }
    }
}
