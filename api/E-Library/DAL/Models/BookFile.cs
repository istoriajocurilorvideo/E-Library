namespace ELibrary.DAL.Models
{
    public class BookFile : BaseEntity
    {
        public BookFile()
        {
            FileType = string.Empty;
            CoverType = string.Empty;
            FileContent = Array.Empty<byte>();
            CoverContent = Array.Empty<byte>();
        }

        public byte[] FileContent { get; set; }
        public byte[] CoverContent { get; set; }
        public string? FileType { get; set; }
        public string? CoverType { get; set; }
        public Book? Book { get; set; }
    }
}