using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplicationParkinson.IServices;
using WebApplicationParkinson.Model;

namespace Multiverse.Controllers
{
    [EnableCors("AllowAll")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersControllers : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsersService _usersService;
        private readonly ServiceContext _serviceContext;
        public UsersControllers (IConfiguration configuration, IUsersService usersService, ServiceContext serviceContext)
        {
            _configuration = configuration;
            _usersService = usersService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertUsers")]
        public IActionResult Post([FromBody] UsersItems Users)
        {
            try
            {
                return Ok(_usersService.InsertUsers(Users));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el ID del rol: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestModel loginRequest)
        {
            try
            {
                var user = _serviceContext.UsersItems.FirstOrDefault(u => u.UserName == loginRequest.UserName);

                if (user != null && loginRequest.Password == user.Password)
                {
                    var token = GenerateJwtToken(user);
                    return Ok(new { Token = token });
                }
                else
                {
                    return StatusCode(401, "Credenciales incorrectas");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al iniciar sesión: {ex.Message}");
            }
        }

        private string GenerateJwtToken(UsersItems Users)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, Users.Id_Users.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}