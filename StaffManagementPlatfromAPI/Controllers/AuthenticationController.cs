using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StaffManagementPlatfromAPI.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StaffManagementPlatfromAPI.Controllers
{
    [Route("api/[anthentication]")]
    [ApiController]


    public class AuthenticationRequestBody
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class StaffUser
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public StaffUser(int userId, string email, string firstName, string lastName,string city)
        {
            UserId = userId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            City = city;
        }
    }
 

    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpPost("authenticate")]

        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {

            // 1. validate username and passowrd

            var user = ValidateteUserCredentials(authenticationRequestBody.Email,
                authenticationRequestBody.Password);

            if (user is null)
            {
                return Unauthorized();
            }
            // 2  create a token
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            //the claims
            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user.UserId.ToString()),
                new Claim("given_name", user.FirstName),
                new Claim("family_name", user.LastName),
                new Claim("city", user.City)
            };
            var jwtSecurityToken = new JwtSecurityToken(
             _configuration["Authentication:Issuer"],
             _configuration["Authentication:Audience"],
             claimsForToken,
             DateTime.UtcNow,
             DateTime.UtcNow.AddHours(1),
             signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
               .WriteToken(jwtSecurityToken);
            return Ok(tokenToReturn);
        }

        private StaffUser ValidateteUserCredentials(string email, string password)
        {
            return new StaffUser(1, email ?? "", "John", "Deo", "Lagos");
        }
    }
}

