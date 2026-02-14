using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        [Route("GenerteToken")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            /*
             * grab user name and password from the request
             * check the user name and password with the database
             * if username and passwor is correct, then AUTHENTICATE the user
             * based the the user role I will give the AUTHORIZATION to access the resource i.e admin,viewer,editor etc
             * 
             * Then generate token
             */
            //Claims are used to pass user info i.e name, role,email etc

            if (userName.ToLower() == "test" && password.ToLower() == "password")
            {
                DateTime curre = DateTime.UtcNow;

                DateTime tokenExpiryTime = DateTime.UtcNow.AddMinutes(10); // this line is used to set the token expiration time to 1 hour from the current time

                var tokenHandlar = new JwtSecurityTokenHandler();

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("60cace8f-bc24-47cb-bb12-ebceba73220b")); // this line is used to create a symmetric security key using the secret key string

                var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // this line is used to create signing credentials using the symmetric security key and the HMAC SHA256 algorithm

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Expires = tokenExpiryTime,
                    SigningCredentials = signingCredentials,
                    Subject = new System.Security.Claims.ClaimsIdentity(new[]
                    {
                        new Claim("UserRole", "Admin"),
                        new Claim("UserName", "admiAdmin User"),
                        new Claim(ClaimTypes.Expiration, tokenExpiryTime.ToString("MMM ddd dd yyyy HH: mm:ss:tt"))
                    }) // this line is used to create a claims identity with the specified claims (name and role in this case)
                };

                var token = tokenHandlar.CreateToken(tokenDescriptor); // this line is used to create a JWT token using the token descriptor

                var realtoken = tokenHandlar.WriteToken(token);

                return Ok(realtoken);

            }       
            return Unauthorized();
        }
    }
}
