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
    }
}
