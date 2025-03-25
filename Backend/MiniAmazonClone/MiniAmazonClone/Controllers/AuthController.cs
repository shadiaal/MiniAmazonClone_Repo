using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniAmazonClone.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniAmazonClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // api/Auth/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] Register registerModel)
        {
           
            if (registerModel == null || string.IsNullOrEmpty(registerModel.Email) || string.IsNullOrEmpty(registerModel.Password))
            {
                return BadRequest("Invalid registration data.");
            }

            var user = new User
            {
                Name = registerModel.Name,
                Email = registerModel.Email,
                Password = registerModel.Password, 
                Role = "User" 
            };

        

            // After adding the user, generate the JWT Token for the user.
            var token = GenerateJwtToken(registerModel.Email, "User");
            return Ok(new { token });
        }

        // api/Auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            // Authenticate the user
            if (login.Email == "admin@example.com" && login.Password == "adminpassword")
            {
                var token = GenerateJwtToken(login.Email, "Admin");
                return Ok(new { token });
            }
            else if (login.Email == "user@example.com" && login.Password == "userpassword")
            {
                var token = GenerateJwtToken(login.Email, "User");
                return Ok(new { token });
            }
            return Unauthorized();
        }

        // api/Auth/user/profile
        [Authorize] 
        [HttpGet("user/profile")]
        public IActionResult GetProfile()
        {
           
            var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(userEmail))
            {
                return Unauthorized();
            }

      
            var userProfile = new
            {
                Email = userEmail,
                Name = "John Doe", 
                Role = User.FindFirst(ClaimTypes.Role)?.Value
            };

            return Ok(userProfile);
        }

        //Modify the use of Claims when registering and add permissions
        private string GenerateJwtToken(string userName, string role)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, userName),
        new Claim(ClaimTypes.Role, role) 
    };

            if (role == "Admin")
            {
                claims.Add(new Claim("CanRefundOrders", "true"));
            }
            else
            {
                claims.Add(new Claim("CanViewOrders", "true"));
            }

            var key = new SymmetricSecurityKey(secretKey);
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
