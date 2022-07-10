using ELibrary.DAL.Repositories;

namespace ELibrary.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly ELibraryDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(ELibraryDbContext eventContext, IServiceProvider serviceProvider)
        {
            _dbContext = eventContext;
            this._serviceProvider = serviceProvider;
        }

        private BookRepository? _bookRepositoryField;
        public BookRepository BookRepository
        {
            get
            {
                if (_bookRepositoryField == null)
                    _bookRepositoryField = new BookRepository(_dbContext, this);

                return _bookRepositoryField;
            }
        }

        private BookFileRepository? _bookFileRepository;
        public BookFileRepository BookFileRepository
        {
            get
            {
                if (_bookFileRepository == null)
                    _bookFileRepository = new BookFileRepository(_dbContext, this);

                return _bookFileRepository;
            }
        }


        private BookAuthorRepository? _bookAuthorRepositoryField;
        public BookAuthorRepository BookAuthorRepository
        {
            get
            {
                if (_bookAuthorRepositoryField == null)
                    _bookAuthorRepositoryField = new BookAuthorRepository(_dbContext, this);

                return _bookAuthorRepositoryField;
            }
        }

        private BookGenreRepository? _bookGenreRepositoryField;
        public BookGenreRepository BookGenreRepository
        {
            get
            {
                if (_bookGenreRepositoryField == null)
                    _bookGenreRepositoryField = new BookGenreRepository(_dbContext, this);

                return _bookGenreRepositoryField;
            }
        }

        private UserRepository? _userRepository;
        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbContext, this, _serviceProvider);

                return _userRepository;
            }
        }

        public void SaveChanges() => _dbContext.SaveChanges();

        public void Dispose() => _dbContext?.Dispose();
    }
}
