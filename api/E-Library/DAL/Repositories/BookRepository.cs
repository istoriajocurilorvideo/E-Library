using ELibrary.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ELibrary.DAL.Repositories
{
    public class BookRepository : BaseRepository
    {
        public BookRepository(ELibraryDbContext dbContext, UnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public Book? GetById(int id) => _dbContext.Books.Include(x => x.Genres).Include(x => x.Authors).FirstOrDefault(x => x.Id == id);
        public IEnumerable<Book> GetAll(Expression<Func<Book, bool>>? filter = null)
        {
            IQueryable<Book> query = _dbContext.Books;

            query = query.Include(x => x.Genres).Include(x => x.Authors).Include(x => x.File);

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }

        public Book Create(string isbn, string intro, string title, string description, int[] genreIds, int[] authorIds)
        {
            var newBook = new Book
            {
                ISBN = isbn,
                Intro = intro,
                Description = description,
                Title = title
            };
            newBook.Genres?.Clear();
            newBook.Authors?.Clear();

            if (genreIds?.Any() ?? false)
            {
                newBook.Genres = _unitOfWork.BookGenreRepository.GetAll(x => genreIds.Contains(x.Id)).ToList();
            }

            if (authorIds?.Any() ?? false)
            {
                newBook.Authors = _unitOfWork.BookAuthorRepository.GetAll(x => authorIds.Contains(x.Id)).ToList();
            }

            _dbContext.Books.Add(newBook);

            return newBook;
        }

        public Book? Update(int id, string isbn, string intro, string title, string description, int[] genreIds, int[] authorIds)
        {
            var currentBook = GetById(id);
            if (currentBook == null)
                throw new ArgumentException(null, nameof(id));
        
            currentBook.ISBN = isbn;
            currentBook.Intro = intro;
            currentBook.Description = description;
            currentBook.Title = title;
            currentBook.Genres?.Clear();
            currentBook.Authors?.Clear();

            if(genreIds?.Any() ?? false)
            {
                currentBook.Genres = _unitOfWork.BookGenreRepository.GetAll(x => genreIds.Contains(x.Id)).ToList();
            }

            if (authorIds?.Any() ?? false)
            {
                currentBook.Authors = _unitOfWork.BookAuthorRepository.GetAll(x => authorIds.Contains(x.Id)).ToList();
            }

            _dbContext.Books.Update(currentBook);

            return currentBook;
        }

        public void Delete(int authorId)
        {
            Book? book = GetById(authorId);
            if (book == null)
                return;

            _dbContext.Books.Remove(book);
        }
    }
}
