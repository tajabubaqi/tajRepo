using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Creative_Harmony.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Creative_Harmony.Controllers
{
    public class AdminController : Controller
    {
        private IConfiguration _config;

        public AdminController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet, Authorize]
        public IEnumerable<Users> GetAll()
        {
            var context = new HarmonyContext();
            List<Users> users = context.users.ToList<Users>();
            return users;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken(IFormCollection Logginguser)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(Logginguser);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string BuildToken(Users user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Users Authenticate(IFormCollection user)
        {
            var context = new HarmonyContext();
            List<Users> users = context.users.Where(u => user["email"] == u.Name && user["pass"] == u.Password).ToList<Users>();
            if (users.Count > 0)
                return users[0];
            else return null;

        }
    }
}
