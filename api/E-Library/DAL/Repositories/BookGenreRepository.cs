using ELibrary.DAL.Models;
using System.Linq.Expressions;

namespace ELibrary.DAL.Repositories
{
    public class BookGenreRepository : BaseRepository
    {
        public BookGenreRepository(ELibraryDbContext dbContext, UnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public BookGenre? GetById(int id) => _dbContext.BookGenres.FirstOrDefault(x => x.Id == id);
        public IEnumerable<BookGenre> GetAll(Expression<Func<BookGenre, bool>>? filter = null)
        {
            IQueryable<BookGenre> query = _dbContext.BookGenres;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }
        public BookGenre Create(string name)
        {
            BookGenre newBook = new()
            {
                CreationDate = DateTime.Now,
                Name = name
            };


            _dbContext.BookGenres.Add(newBook);
            return newBook;
        }
        public BookGenre? Update(int id, string name)
        {
            var currentBook = GetById(id);
            if (currentBook != null)
            {
                currentBook.Name = name;

                _dbContext.BookGenres.Update(currentBook);
            }

            return currentBook;
        }
        public void Delete(int genreId)
        {
            BookGenre? genre = GetById(genreId);
            if (genre == null)
                return;

            _dbContext.BookGenres.Remove(genre);
        }
        public IEnumerable<Tuple<BookGenre, int>> GetSummary() => _dbContext.Books.SelectMany(x => x.Genres).GroupBy(x => x).Select(x => new Tuple<BookGenre, int>(x.Key, x.Count()));
    }
}
