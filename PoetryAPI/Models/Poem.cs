namespace PoetryAPI.Models
{
    public class Poem
    {
        public Poem()
        {
            Title = "";
            Author = "";
            Lines = new string[0];
        }
        public Poem(string title, string author, string[] lines)
        {
            Title = title;
            Author = author;
            Lines = lines;
        }
        public Poem(int id, string title, string author, string[] lines)
        {
            Id = id;
            Title = title;
            Author = author;
            Lines = lines;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string[] Lines { get; set; }
    }
}
