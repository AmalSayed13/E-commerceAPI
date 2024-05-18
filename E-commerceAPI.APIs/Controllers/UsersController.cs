using E_commerceAPI.BL.Dtos.User;
using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_commerceAPI.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public UsersController(IConfiguration configuration , UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            bool isAuthenticated = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isAuthenticated)
            {
                return Unauthorized();

            }
            var Userclaims = await _userManager.GetClaimsAsync(user);
            
            
            var KeyFromConfig = _configuration.GetValue<string>(Constants.AppSettings.SecretKey)!;
            var KeyInBytes = Encoding.ASCII.GetBytes(KeyFromConfig);
            var Key = new SymmetricSecurityKey(KeyInBytes);

            var signingCredentials = new SigningCredentials(Key,
                SecurityAlgorithms.HmacSha256Signature);

            var expiryDateTime = DateTime.Now.AddDays(2);
            var jwt = new JwtSecurityToken(
               claims: Userclaims , signingCredentials : signingCredentials,
               expires : expiryDateTime
               );

            var jwtAsString = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new TokenDto(jwtAsString, expiryDateTime);
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Address = registerDto.Address,
                PhoneNumber = registerDto.PhoneNumber,
                Age = registerDto.Age,
                
            };
        var result = await _userManager.CreateAsync(user, registerDto.Password);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier , user.Id.ToString()),
                new (ClaimTypes.Name , user.UserName),
                new (ClaimTypes.Email, user.Email),
                new ("PhoneNumber", user.PhoneNumber),
                new ("Address", user.Address),
                new ("Role", user.UserRole)         
            };
          await  _userManager.AddClaimsAsync(user, claims);
            return Ok("Register Successflly, Please login");
        }
    }
}
