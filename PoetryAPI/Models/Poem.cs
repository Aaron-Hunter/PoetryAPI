namespace PoetryAPI.Models
{
    public class Poem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string[] Lines { get; set; }
    }
}
