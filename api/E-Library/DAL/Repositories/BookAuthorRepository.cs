using ELibrary.DAL.Models;
using System.Linq.Expressions;

namespace ELibrary.DAL.Repositories
{
    public class BookAuthorRepository : BaseRepository
    {
        public BookAuthorRepository(ELibraryDbContext dbContext, UnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public BookAuthor? GetById(int id) => _dbContext.BookAuthors.FirstOrDefault(x => x.Id == id);
        public IEnumerable<BookAuthor> GetAll(Expression<Func<BookAuthor, bool>>? filter = null)
        {
            IQueryable<BookAuthor> query = _dbContext.BookAuthors;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }
        public BookAuthor Create(string name)
        {
            BookAuthor newBook = new()
            {
                CreationDate = DateTime.Now,
                Name = name,
            };


            _dbContext.BookAuthors.Add(newBook);
            return newBook;
        }
        public BookAuthor? Update(int id, string name)
        {
            var currentAuthor = GetById(id);
            if (currentAuthor != null)
            {
                currentAuthor.Name = name;

                _dbContext.BookAuthors.Update(currentAuthor);
            }

            return currentAuthor;
        }
        public void Delete(int authorId)
        {
            BookAuthor? genre = GetById(authorId);
            if (genre == null)
                return;

            _dbContext.BookAuthors.Remove(genre);
        }
        public IEnumerable<Tuple<BookAuthor, int>> GetSummary() => _dbContext.Books.SelectMany(x => x.Authors).GroupBy(x => x).Select(x => new Tuple<BookAuthor, int>(x.Key, x.Count()));
    }
}