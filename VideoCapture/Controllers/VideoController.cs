using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace VideoCapture.Controllers
{
    public class VideoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveRecordFile()
        {
            if(Request.Form.Files.Any())
            {
                var file = Request.Form.Files["video-blob"];
                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedFiles");
                string fileName = Guid.NewGuid().ToString() + "_" + file.FileName + ".webm";
                string uploadPath = Path.Combine(uploadFolder, fileName);
                await file.CopyToAsync(new FileStream(uploadPath, FileMode.Create));
            }

            return Json(HttpStatusCode.OK);
        }
    }
}
