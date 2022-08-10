using Microsoft.AspNetCore.Mvc;
using PoetryAPI.Services;
using PoetryAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoetryAPI.Controllers
{
    /// <summary>
    /// Controller that implements CRUD operations for Poems
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PoemController : ControllerBase
    {
        private PoetryService _poetryService;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initialises a new instance of the PoemController class.
        /// </summary>
        public PoemController(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _poetryService = new PoetryService(clientFactory);
            _configuration = configuration;
        }

        /// <summary>
        /// Gets the title, author and lines of all poems matching the given title
        /// </summary>
        [HttpGet("{title}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var content = _poetryService.GetContentFromTitle(_configuration["ClientBaseUri"], title);
            return Ok(content.Result);
        }

        /// <summary>
        /// Gets all Poems stored in PoemDataService
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<Poem>> GetAll() => PoemDataService.GetAll();

        /// <summary>
        /// Saves the first result of Get request as Poem in PoemDataService
        /// </summary>
        [HttpPost("{title}")]
        public async Task<IActionResult> CreateByTitle(string title)
        {
            var rawPoem = _poetryService.RawPoemFromTitle(_configuration["ClientBaseUri"], title).Result;
            if (rawPoem is null)
            {
                return BadRequest();
            }
            PoemDataService.Add(rawPoem);
            return CreatedAtAction(nameof(CreateByTitle), new { title = rawPoem.Title}, rawPoem);
        }

        /// <summary>
        /// Updates the details of a poem stored in PoemDataService
        /// </summary>
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

        /// <summary>
        /// Deletes a poem from PoemDataService
        /// </summary>
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
