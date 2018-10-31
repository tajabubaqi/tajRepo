using Creative_Harmony.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Creative_Harmony.Controllers
{
    [Route("/images")]
    [ApiController]
    public class ImagesController : Controller
    {
        private IHostingEnvironment _env;
        public ImagesController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpPost("employees")]
        public async Task<IActionResult> PostEmployees(IFormFile file, IFormCollection param)
        {
            //  Getting Employees Attribute
            var filePath = $"{_env.WebRootPath}/images/employees/{file.FileName}";
            var empName = param.ContainsKey("empName") ? param["empName"].ToString() : "No Name Specified";

            try
            {
                //  Copying Image to Server Root Directory 
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                //Adding Records to Database
                using (var context = new HarmonyContext())
                {
                    var employee = new Employees()
                    {
                        Name = empName,
                        ImagePath = filePath
                    };

                    context.employees.Add(employee);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return BadRequest("Upload Image Failed");
            }

            return Ok(filePath);
        }

        [HttpPost("partners")]
        public async Task<IActionResult> PostParters(IFormFile file, IFormCollection param)
        {

            //  Getting Employees Attribute
            var filePath = $"{_env.WebRootPath}/images/partners/{file.FileName}";
            var partName = param.ContainsKey("partName") ? param["partName"].ToString() : "No Name Specified";

            try
            {
                //  Copying Image to Server Root Directory 
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                //Adding Records to Database
                using (var context = new HarmonyContext())
                {
                    var employee = new Employees()
                    {
                        Name = partName,
                        ImagePath = filePath
                    };

                    context.employees.Add(employee);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return BadRequest("Upload Image Failed");
            }

            return Ok(filePath);
        }
    }
}
