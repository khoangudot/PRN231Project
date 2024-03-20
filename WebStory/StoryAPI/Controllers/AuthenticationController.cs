using BussinessObjects.Dtos;
using DataAccess.Repository.Irepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        protected ResponseDto _response;
        private IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _response = new ResponseDto();
        }

        [AllowAnonymous]
        [HttpGet("authenticate/{email}/{password}")]
        public async Task<object> Authenticate(string email, string password)
        {
            try
            {
                UserDTO userDto = await _userRepository.GetUserByEmailAndPassword(email, password);
                if (userDto != null)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:7016",
                        audience: "https://localhost:7142",
                        claims: new Claim[]
                        {
                            new Claim("Id", userDto.UserId.ToString()),
                            new Claim("Email", userDto.Email),
                            new Claim("Role", userDto.RoleId.ToString()),
                            new Claim(ClaimTypes.Role, userDto.RoleId.ToString())
                        },
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    _response.IsSuccess = true;
                    _response.Result = tokenString;
                }

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
