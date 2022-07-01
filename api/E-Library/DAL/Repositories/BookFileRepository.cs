using ELibrary.DAL.Models;

namespace ELibrary.DAL.Repositories
{
    public class BookFileRepository : BaseRepository
    {
        public BookFileRepository(ELibraryDbContext dbContext, UnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public BookFile? GetById(int id) => _dbContext.BookFiles.FirstOrDefault(x => x.Id == id);
        
        public BookFile Create(int bookId, byte[] fileContent, string fileType, byte[] coverContent, string coverType)
        {
            BookFile newBook = new()
            {
                Id = bookId,
                FileContent =  fileContent,
                FileType = fileType,
                CoverContent = coverContent, 
                CoverType = coverType,
                CreationDate = DateTime.Now
            };

            _dbContext.BookFiles.Add(newBook);
            return newBook;
        }
        public BookFile? UpdateFile(int id, byte[] fileContent, string fileType)
        {
            var currentBookFile = GetById(id);
            if (currentBookFile != null)
            {
                currentBookFile.FileContent = fileContent;
                currentBookFile.FileType = fileType;

                _dbContext.BookFiles.Update(currentBookFile);
            }
            else
                Create(id, fileContent, fileType, Array.Empty<byte>(), string.Empty);

            return currentBookFile;
        }
        public BookFile? UpdateCover(int id, byte[] coverContent, string contentType)
        {
            var currentBookFile = GetById(id);
            if (currentBookFile != null)
            {
                currentBookFile.CoverContent = coverContent;
                currentBookFile.CoverType = contentType;

                _dbContext.BookFiles.Update(currentBookFile);
            }
            else
                Create(id, Array.Empty<byte>(), string.Empty, coverContent, contentType);

            return currentBookFile;
        }
        
        public void Delete(int id)
        {
            BookFile? bookFile = GetById(id);
            if (bookFile == null)
                return;

            _dbContext.BookFiles.Remove(bookFile);
        }
    }
}
