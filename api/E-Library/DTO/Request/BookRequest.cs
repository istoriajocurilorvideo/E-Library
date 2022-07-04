
namespace ELibrary.DTO.Response
{
    public class BookRequest
    {
        public BookRequest()
        {
            Title = string.Empty;
            Intro = string.Empty;
            Description = string.Empty;
            ISBN = string.Empty;

            Genres = Array.Empty<int>();
            Authors = Array.Empty<int>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public int[] Authors { get; set; }
        public int[] Genres { get; set; }
    }
}