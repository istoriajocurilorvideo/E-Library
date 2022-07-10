namespace ELibrary.DAL.Models
{
    public class BookAuthor : BaseEntity
    {
        public BookAuthor()
        {
            Name = string.Empty;
        }

        public string Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
