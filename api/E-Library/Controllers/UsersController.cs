using ELibrary.DAL;
using ELibrary.DTO;
using ELibrary.DTO.Response;
using ELibrary.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ELibrary.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        private readonly UnitOfWork UnitOfWork;

        public UsersController(UnitOfWork unitOfWork, IConfiguration configuration)
        {
            UnitOfWork = unitOfWork;
            Configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<UserRegisterResponse> Register(UserRegisterRequest data)
        {
            UserRegisterResponse response = new();

            if (!ModelState.IsValid)
            {
                response.ErrorMessage = "Data is invalid";
                response.IsOk = false;
                return response;
            }

            try
            {
                var user = await UnitOfWork.UserRepository.CreateAsync(data.Email, data.Password);
                if (user == null)
                {
                    response.IsOk = false;
                    response.ErrorMessage = "Could not create user";
                }
                else
                {
                    response.IsOk = true;
                }
            }
            catch (Exception ex)
            {
                response.IsOk = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]UserLoginRequest loginData)
        {
            var user = await UnitOfWork.UserRepository.GetByEmailAsync(loginData.Email);
            if (user == null)
                return Unauthorized();

            var result = await HttpContext.RequestServices.GetRequiredService<SignInManager<IdentityUser>>().PasswordSignInAsync(loginData.Email, loginData.Password, true, false);

            if (!result.Succeeded || result.IsLockedOut)
                return Unauthorized();

            return Ok(await GetToken(user));
        }

        [HttpGet]
        [Authorize]
        public async Task<UserLogoutResponse> Logout()
        {
            await HttpContext.RequestServices.GetRequiredService<SignInManager<IdentityUser>>().SignOutAsync();
            return new UserLogoutResponse();
        }

        private async Task<JwtToken> GetToken(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(await GetClaims(user)),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new JwtToken { Token = tokenHandler.WriteToken(token) };
        }
        private async Task<List<Claim>> GetClaims(IdentityUser user)
        {
            IdentityOptions _options = new();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
                new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName)
            };
            claims.AddRange(await UnitOfWork.UserRepository.GetClaimsAsync(user));
            claims.AddRange((await UnitOfWork.UserRepository.GetUserRolesAsync(user)).Select(x => new Claim(ClaimTypes.Role, x)));

            return claims;
        }
    }
}