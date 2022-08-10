namespace PoetryAPI.Models
{
    /// <summary>
    /// A class to store Poem data returned from API in PoemDataService.
    /// </summary>
    public class Poem
    {
        /// <summary>
        /// The unique identifier for each instance.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the poem.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The author of the poem.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// The lines of the poem.
        /// </summary>
        public string[] Lines { get; set; }

        /// <summary>
        /// Initialises a new empty instance of the Poem class.
        /// </summary>
        public Poem()
        {
            Title = "";
            Author = "";
            Lines = new string[0];
        }

        /// <summary>
        /// Initialises a new instance of the Poem class.
        /// </summary>
        /// <param name="title">The title of the poem</param>
        /// <param name="author">The author of the poem</param>
        /// <param name="lines">The lines of the poem</param>
        public Poem(string title, string author, string[] lines)
        {
            Title = title;
            Author = author;
            Lines = lines;
        }

        /// <summary>
        /// Initialises a new instance of the Poem class.
        /// </summary>
        /// <param name="id">Unique identifier for this instance of Poem</param>
        /// <param name="title">The title of the poem</param>
        /// <param name="author">The author of the poem</param>
        /// <param name="lines">The lines of the poem</param>
        public Poem(int id, string title, string author, string[] lines)
        {
            Id = id;
            Title = title;
            Author = author;
            Lines = lines;
        }        
    }
}
