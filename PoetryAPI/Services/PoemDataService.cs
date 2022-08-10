using PoetryAPI.Models;

namespace PoetryAPI.Services
{
    /// <summary>
    /// A Static DataService to act as a local data storage
    /// </summary>
    public static class PoemDataService
    {
        static List<Poem> Poems { get; }
        static int nextId = 0;
        static PoemDataService()
        {
            Poems = new List<Poem>
            {
            };
        }

        /// <summary>
        /// Returns a List containing all the Poems in the DataService.
        /// </summary>
        public static List<Poem> GetAll() => Poems;

        /// <summary>
        /// Gets a Poem by id.
        /// </summary>
        public static Poem? Get(int id) => Poems.FirstOrDefault(p => p.Id == id);

        /// <summary>
        /// Gets a Poem by title.
        /// </summary>
        public static Poem? Get(string title) => Poems.FirstOrDefault(p => p.Title == title);

        /// <summary>
        /// Adds a Poem to the DataService.
        /// </summary>
        public static void Add(Poem poem)
        { 
            poem.Id = nextId++;
            Poems.Add(poem);
        }

        /// <summary>
        /// Adds a Poem to the DataService by constructing a Poem from a RawPoem.
        /// </summary>
        public static void Add(RawPoem rawPoem)
        {
            var poem = new Poem(rawPoem.Title, rawPoem.Author, rawPoem.Lines);
            poem.Id = nextId++; ;
            Poems.Add(poem);
        }

        /// <summary>
        /// Deletes a Poem by id.
        /// </summary>
        public static void Delete(int id)
        {
            var poem = Get(id);
            if (poem is null)
                return;

            Poems.Remove(poem);
        }

        /// <summary>
        /// Deletes a Poem by title.
        /// </summary>
        public static void Delete(string title)
        {
            var poem = Get(title);
            if (poem is null)
                return;

            Poems.Remove(poem);
        }

        /// <summary>
        /// Updates a poem by id.
        /// </summary>
        public static void Update(Poem poem)
        {
            var index = Poems.FindIndex(p => p.Id == poem.Id);
            if (index == -1)
                return;

            Poems[index] = poem;
        }
    }
}
