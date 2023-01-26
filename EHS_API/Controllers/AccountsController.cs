using EHS_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MovieStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        public AccountsController(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDetails userDetails)
        {
            if (userDetails == null)
            {
                return BadRequest();
            }
            _dbContext.Users.Add(userDetails);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            //var currentUser = _dbContext.Users.FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);
            var currentUser = _dbContext.Users.FirstOrDefault
                (x => x.UserName == login.UserName && EF.Functions.Collate(x.Password, "SQL_Latin1_General_CP1_CS_AS") == login.Password);
            if (currentUser == null)
            {
                return NotFound("Invalid Username or Password");
            }
            var token = GenerateToken(currentUser);
            if (token == null)
            {
                return NotFound("Invalid credentials");
            }
            return Ok(token);
        }

        [NonAction]
        public string GenerateToken(UserDetails userDetails)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var myClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userDetails.UserName),
                new Claim(ClaimTypes.Email, userDetails.Email),
            };

            var token = new JwtSecurityToken(issuer: _configuration["JWT:issuer"],
                                             claims: myClaims,
                                             expires: DateTime.Now.AddDays(1),
                                             signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet("GetName"), Authorize]
        public IActionResult GetName()
        {
            var UserName = User.FindFirstValue(ClaimTypes.Name);
            return Ok(UserName);
        }
    }
}
