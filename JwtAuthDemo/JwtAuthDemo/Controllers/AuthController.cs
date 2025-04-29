using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthDemo.Model;
using Microsoft.AspNetCore.Authorization;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }
        /// <summary>
        /// Login endpoint to authenticate users and generate JWT token
        /// </summary>
        /// <param name="model">The login model containing username and password</param>
        /// <returns>Returns a JWT token if authentication is successful, otherwise returns Unauthorized</returns>
        [Authorize=] // TODO: Fix the Authorize attribute syntax if needed
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Check if the provided username and password match the hardcoded credentials
            if (model.Username == "admin" && model.Password == "password123")
            {
                // Generate a JWT token for the authenticated user
                var token = GenerateToken(model.Username);
                // Return the generated token in the response
                return Ok(new { token });
            }

            // Return Unauthorized response if credentials are invalid
            return Unauthorized("Invalid credentials");
        }
        /// <summary>
        /// Generates a JWT token for the authenticated user and assigns the role as Admin.
        /// </summary>
        /// <param name="username">The username of the authenticated user.</param>
        /// <returns>Returns a signed JWT token as a string.</returns>
        private string GenerateToken(string username)
        {
            // Retrieve the secret key from configuration and create a symmetric security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            // Create signing credentials using the security key and HMAC-SHA256 algorithm
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Define the claims for the token, including the username and role
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username), // Add the username claim
                new Claim(ClaimTypes.Role, "Admin")   // Add the role claim as Admin
            };

            // Create the JWT token with issuer, audience, claims, expiration, and signing credentials
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"], // Token issuer
                audience: _config["Jwt:Audience"], // Token audience
                claims: claims, // Claims to include in the token
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_config["Jwt:ExpireMinutes"])), // Token expiration time
                signingCredentials: creds // Signing credentials
            );

            // Write and return the token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}