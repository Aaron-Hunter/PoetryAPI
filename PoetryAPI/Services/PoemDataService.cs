using PoetryAPI.Models;

namespace PoetryAPI.Services
{
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

        public static List<Poem> GetAll() => Poems;

        public static Poem? Get(int id) => Poems.FirstOrDefault(p => p.Id == id);

        public static Poem? Get(string title) => Poems.FirstOrDefault(p => p.Title == title);

        public static void Add(Poem poem)
        { 
            poem.Id = nextId++;
            Poems.Add(poem);
        }

        public static void Add(RawPoem rawPoem)
        {
            var poem = new Poem(rawPoem.Title, rawPoem.Author, rawPoem.Lines);
            poem.Id = nextId++; ;
            Poems.Add(poem);
        }

        public static void Delete(int id)
        {
            var poem = Get(id);
            if (poem is null)
                return;

            Poems.Remove(poem);
        }

        public static void Delete(string title)
        {
            var poem = Get(title);
            if (poem is null)
                return;

            Poems.Remove(poem);
        }

        public static void Update(Poem poem)
        {
            var index = Poems.FindIndex(p => p.Id == poem.Id);
            if (index == -1)
                return;

            Poems[index] = poem;
        }
    }
}
