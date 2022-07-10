using System.ComponentModel.DataAnnotations;

namespace ELibrary.DTO
{
    public class UserLoginRequest
    {
        public UserLoginRequest()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
