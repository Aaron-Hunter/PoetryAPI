using Newtonsoft.Json;

namespace PoetryAPI.Models
{
    public class RawPoem
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("lines")]
        public string[] Lines { get; set; }
        public RawPoem()
        {
            Title = "";
            Author = "";
            Lines = new string[0];
        }
        public RawPoem(string title, string author, string[] lines)
        {
            Title = title;
            Author = author;
            Lines = lines;
        }
    }
}
