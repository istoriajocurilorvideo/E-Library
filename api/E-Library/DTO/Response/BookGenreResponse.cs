using ELibrary.DAL.Models;

namespace ELibrary.DTO.Response
{
    public class BookGenreResponse
    {
        public BookGenreResponse(BookGenre bookGenre)
        {
            Id = bookGenre.Id;
            Name = bookGenre.Name;
        }

        public BookGenreResponse()
        {
            Name = string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
