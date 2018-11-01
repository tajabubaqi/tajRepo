using System.Collections.Generic;
using System.Linq;
using Creative_Harmony.AppServices;
using Creative_Harmony.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
            
        [HttpPost]
        public IActionResult CreateToken(IFormCollection user)
        {
            IActionResult response = Unauthorized();
            var context = new HarmonyContext();

            bool isAuthorized = context.users.Any(u => user["email"] == u.Name && user["pass"] == u.Password);

            if (isAuthorized)
            {
                var tokenString = JWT.BuildToken(_config);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [HttpGet, Authorize]
        public IEnumerable<Users> GetAll()
        {
            var context = new HarmonyContext();
            List<Users> users = context.users.ToList<Users>();
            return users;
        }

    }
}
