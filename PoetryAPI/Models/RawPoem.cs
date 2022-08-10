using Newtonsoft.Json;

namespace PoetryAPI.Models
{
    /// <summary>
    /// A class to store raw Poem data returned from the API.
    /// </summary>
    public class RawPoem
    {
        /// <summary>
        /// The title of the poem.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// The author of the poem.
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// The lines of the poem.
        /// </summary>
        [JsonProperty("lines")]
        public string[] Lines { get; set; }

        /// <summary>
        /// Initialises a new empty instance of the RawPoem class.
        /// </summary>
        public RawPoem()
        {
            Title = "";
            Author = "";
            Lines = new string[0];
        }

        /// <summary>
        /// Initialises a new instance of the RawPoem class.
        /// </summary>
        /// <param name="title">The title of the poem</param>
        /// <param name="author">The author of the poem</param>
        /// <param name="lines">The lines of the poem</param>
        public RawPoem(string title, string author, string[] lines)
        {
            Title = title;
            Author = author;
            Lines = lines;
        }
    }
}
