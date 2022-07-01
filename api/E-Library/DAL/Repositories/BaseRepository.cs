using Microsoft.AspNetCore.Identity;

namespace ELibrary.DAL.Repositories
{
    public class BaseRepository
    {
        protected readonly ELibraryDbContext _dbContext;
        protected readonly UnitOfWork _unitOfWork;

        public BaseRepository(ELibraryDbContext dbContext, UnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
    }
}
