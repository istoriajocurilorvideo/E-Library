namespace ELibrary.DAL.Models
{
    public class BookGenre : BaseEntity
    {
        public BookGenre()
        {
            Name = string.Empty;
        }

        public string Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
