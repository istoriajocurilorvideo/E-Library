using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ELibrary.DAL.Repositories
{
    public class UserRepository : BaseRepository
    {
        private IServiceProvider _serviceProvider { get; }

        public UserRepository(ELibraryDbContext dbContext, UnitOfWork unitOfWork, IServiceProvider serviceProvider) : base(dbContext, unitOfWork)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<IdentityUser?> GetByIdAsync(string userId)
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            return await userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<IdentityUser?> GetByEmailAsync(string email)
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            return await userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IdentityUser?> GetByClaimsAsync(ClaimsPrincipal userClaims)
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            return await userManager.GetUserAsync(userClaims);
        }

        public async Task<IdentityUser> CreateAsync(string email, string password)
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = new()
            {
                Email = email,
                UserName = email
            };

            var result = await userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                throw new Exception("Could not create user. Errors:" + string.Join("; ", result.Errors.Select(x => x.Description)));

            return user;
        }

        public async Task<IList<string>> GetUserRolesAsync(IdentityUser user)
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            return await userManager.GetRolesAsync(user);

        }

        public async Task<IList<Claim>> GetClaimsAsync(IdentityUser user)
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            return await userManager.GetClaimsAsync(user);
        }
    }
}
