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
        public async Task<IActionResult> PostEmployees(IFormFile file)
        {

            var filePath = $"{_env.WebRootPath}/images/employees/{file.FileName}";

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Ok(filePath);
        }

        [HttpPost("partners")]
        public async Task<IActionResult> PostParters(IFormFile file)
        {

            var filePath = $"{_env.WebRootPath}/images/partners/{file.FileName}";

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Ok(filePath);
        }
    }
}
