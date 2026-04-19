using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TODO_API.Model;
using System.Xml;

namespace TODO_API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Username and password are required");

            //  Validate user from database
            var user = ValidateUser(request.Username, request.Password);
            if (user == null)
                return Unauthorized("Invalid credentials");

            // JWT Settings
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expiryMinutes = int.Parse(jwtSettings["ExpiryMinutes"]!);

            // Claims include UserId & Role
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role_type)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiresIn = expiryMinutes * 60,

                user = new
                {
                    userId = user.Id,
                    username = user.Username,
                    role = user.Role_type
                }
            });
        }


        // Validate user against API_Users table
        private API_User? ValidateUser(string username, string password)
        {
            using SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using SqlCommand cmd = new SqlCommand(
                "SELECT USER_ID, USERNAME, ROLE_TYPE FROM USERS WHERE USERNAME=@Username AND PASSWORD=@Password", con);

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new API_User
                {
                    Id = (int)reader["USER_ID"],
                    Username = reader["USERNAME"].ToString()!,
                    Role_type = reader["ROLE_TYPE"].ToString()!
                };
            }

            return null;
        }
    }
}
