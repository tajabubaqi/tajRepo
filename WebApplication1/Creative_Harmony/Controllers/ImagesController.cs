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
    [ApiController]
    public class ImagesController : Controller
    {
        private IHostingEnvironment _env;
        public ImagesController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            try
            {
                long size = files.Sum(f => f.Length);

                var filePath = $"{_env.WebRootPath}/images";

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }

                return Ok(new { count = files.Count, size, filePath });
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
