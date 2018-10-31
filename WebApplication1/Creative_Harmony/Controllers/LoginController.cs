using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return Ok(new { email = param["email"].ToString(), password = param["pass"].ToString() });
        }
    }
}
