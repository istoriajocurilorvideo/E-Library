using System.ComponentModel.DataAnnotations;

namespace ELibrary.DTO
{
    public class UserRegisterRequest
    {
        public UserRegisterRequest()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
