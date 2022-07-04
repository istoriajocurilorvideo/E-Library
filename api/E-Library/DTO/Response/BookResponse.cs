using ELibrary.DAL.Models;

namespace ELibrary.DTO.Response
{
    public class BookResponse
    {
        public BookResponse(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Intro = book.Intro;
            Description = book.Description;
            ISBN = book.ISBN;
            FileType = book.File?.FileType ?? string.Empty;

            Genres = book.Genres.Select(x => new BookGenreResponse(x));
            Authors = book.Authors.Select(x => new BookAuthorResponse(x));
        }

        public BookResponse()
        {
            Title = string.Empty;
            Intro = string.Empty;
            Description = string.Empty;
            ISBN = string.Empty;
            FileUrl = string.Empty;
            FileType = string.Empty;
            CoverUrl = string.Empty;

            Genres = new List<BookGenreResponse>();
            Authors = new List<BookAuthorResponse>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public string CoverUrl { get; set; }
        public IEnumerable<BookAuthorResponse> Authors { get; set; }
        public IEnumerable<BookGenreResponse> Genres { get; set; }
    }
}