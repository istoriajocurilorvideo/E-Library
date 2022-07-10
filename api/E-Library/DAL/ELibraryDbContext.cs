using ELibrary.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.DAL
{
    public class ELibraryDbContext : IdentityDbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ELibraryDbContext() : base()
        {
        }

        public ELibraryDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookFile> BookFiles { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(x => x.File)
                .WithOne(x => x.Book)
                .HasForeignKey<BookFile>(x => x.Id);

            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {

            #region genres
            var genre1 = new BookGenre()
            {
                Id = 1,
                Name = "Sciene Fiction",
                CreationDate = DateTime.Now,
            };

            var genre2 = new BookGenre()
            {
                Id = 2,
                Name = "Comedy",
                CreationDate = DateTime.Now,
            };

            var genre3 = new BookGenre()
            {
                Id = 3,
                Name = "Horror",
                CreationDate = DateTime.Now,
            };

            var genre4 = new BookGenre()
            {
                Id = 4,
                Name = "Political",
                CreationDate = DateTime.Now,
            };

            var genre5 = new BookGenre()
            {
                Id = 6,
                Name = "Personal development",
                CreationDate = DateTime.Now,
            };

            modelBuilder.Entity<BookGenre>().HasData(
                genre1,
                genre2,
                genre3,
                genre4,
                genre5
            );
            #endregion

            #region authors
            var author1 = new BookAuthor()
            {
                Id = 1,
                CreationDate = DateTime.Now,
                Name = "Noam Chomsky"
            };

            var author2 = new BookAuthor()
            {
                Id = 2,
                CreationDate = DateTime.Now,
                Name = "Steven King"
            };

            var author3 = new BookAuthor()
            {
                Id = 3,
                CreationDate = DateTime.Now,
                Name = "Jordan Peterson"
            };

            modelBuilder.Entity<BookAuthor>().HasData(
                author1,
                author2,
                author3
             );
            #endregion

            #region books
            var book1 = new Book()
            {
                Id = 1,
                CreationDate = DateTime.Now,
                Title = "Who rules to world?",
                Description = "Great book",
                Intro = "Great book",
                ISBN = "ISBN CODE"
            };

            modelBuilder.Entity<Book>().HasData(
              book1
            );

            var bookFile1 = new BookFile()
            {
                Id = 1,
                CreationDate = DateTime.Now
            };

            modelBuilder.Entity<BookFile>().HasData(
                bookFile1
            );
            #endregion

            #region roles
            var userRole = new IdentityRole()
            {
                Id = "00000000-0000-0000-0000-000000000000",
                Name = "user",
                NormalizedName = "USER"
            };
            var adminRole = new IdentityRole()
            {
                Id = "00000000-0000-0000-0000-000000000001",
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            modelBuilder.Entity<IdentityRole>().HasData(
                userRole,
                adminRole
            );
            #endregion

            #region users
            var passHasher = new PasswordHasher<IdentityUser>();

            var user = new IdentityUser
            {
                Id = "00000000-0000-0000-0000-000000000000",
                Email = "user@elibrary.com",
                NormalizedEmail = "USER@ELIBRARY.COM",
                UserName = "User",
                NormalizedUserName = "USER",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            user.PasswordHash = passHasher.HashPassword(user, "12345");

            var admin = new IdentityUser
            {
                Id = "00000000-0000-0000-0000-000000000001",
                Email = "admin@elibrary.com",
                NormalizedEmail = "ADMIN@ELIBRARY.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            admin.PasswordHash = passHasher.HashPassword(admin, "12345");

            modelBuilder.Entity<IdentityUser>().HasData(
                user,
                admin
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "00000000-0000-0000-0000-000000000000",
                    UserId = "00000000-0000-0000-0000-000000000000"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "00000000-0000-0000-0000-000000000001",
                    UserId = "00000000-0000-0000-0000-000000000000"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "00000000-0000-0000-0000-000000000001",
                    UserId = "00000000-0000-0000-0000-000000000001"
                }
            );

            #endregion
        }

        public static void SeedIdentity(ELibraryDbContext context)
        {
            #region roles
            var roleStore = new RoleStore<IdentityRole>(context);
            string[] roles = new string[] { "User", "Admin" };

            foreach (string role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }
            #endregion

            #region users
            var userStore = new UserStore<IdentityUser>(context);

            var user = new IdentityUser
            {
                Email = "user@elibrary.com",
                NormalizedEmail = "USER@ELIBRARY.COM",
                UserName = "User",
                NormalizedUserName = "USER",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var admin = new IdentityUser
            {
                Email = "admin@elibrary.com",
                NormalizedEmail = "ADMIN@ELIBRARY.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<IdentityUser>();
                var hashed = password.HashPassword(user, "12345");
                user.PasswordHash = hashed;

                var result = userStore.CreateAsync(user);
                IdentityUser attachedUser = userStore.FindByEmailAsync(user.Email).Result;

                userStore.AddToRoleAsync(attachedUser, roles[0]);
            }

            if (!context.Users.Any(u => u.UserName == admin.UserName))
            {
                var password = new PasswordHasher<IdentityUser>();
                var hashed = password.HashPassword(admin, "12345");
                admin.PasswordHash = hashed;

                var result = userStore.CreateAsync(admin);
                IdentityUser attachedUser = userStore.FindByEmailAsync(admin.Email).Result;

                userStore.AddToRoleAsync(attachedUser, roles[0]);
                userStore.AddToRoleAsync(attachedUser, roles[1]);
            }
            #endregion

            context.SaveChanges();
        }
    }
}
