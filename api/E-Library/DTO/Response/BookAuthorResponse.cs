using ELibrary.DAL.Models;

namespace ELibrary.DTO.Response
{
    public class BookAuthorResponse
    {
        public BookAuthorResponse(BookAuthor bookAuthor)
        {
            Id = bookAuthor.Id;
            Name = bookAuthor.Name;
        }

        public BookAuthorResponse()
        {
            Name = string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
