using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaTecnicaCCL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private readonly string SecretKey;

        public Authentication(IConfiguration settings) 
        {
            SecretKey = settings.GetSection("Settings:SecretKey").Value;
        }

        [HttpPost]
        [Route("validation")]
        public IActionResult validationUser([FromBody] User user)
        {
            if (user.Email == "hola@hola.com" && user.Password == "123456") 
            {
                byte[] KeyToBytes = Encoding.ASCII.GetBytes(SecretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Email));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KeyToBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandIer = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandIer.CreateToken(tokenDescriptor);

                string createToken = tokenHandIer.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = createToken });

            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }
    }
}
