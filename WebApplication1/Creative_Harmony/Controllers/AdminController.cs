using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Creative_Harmony.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Creative_Harmony.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Authenticate(IFormCollection param)
        {
            var context = new HarmonyContext();
            List<Users> users = context.users.Where(user => user.Name == param["email"].ToString() && user.Password == param["pass"].ToString()).ToList();
            if (users.Count != 0)
                return Ok(new { email = param["email"], password = param["pass"]});
            else return NotFound();
        }
    }
}
