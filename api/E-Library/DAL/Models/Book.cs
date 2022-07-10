namespace ELibrary.DAL.Models
{
    public class Book : BaseEntity
    {
        public Book()
        {
            Title = string.Empty;
            Intro = string.Empty;
            Description = string.Empty;
            ISBN = string.Empty;
            Authors = new List<BookAuthor>();
            Genres=  new List<BookGenre>(); 
        }

        public string Title { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }

        public BookFile? File { get; set; }
        public ICollection<BookAuthor> Authors { get; set; }
        public ICollection<BookGenre> Genres { get; set; }
    }
}
