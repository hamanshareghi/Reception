using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    //[Authorize(Roles = ("SuperAdmin,Admins"))]
    //[Area("Admin")]
    public class UploadController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;

        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("UploadFiles")]

        [Produces("application/json")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            // Get the file from the POST request
            var theFile = HttpContext.Request.Form.Files.GetFile("file");

            // Get the server path, wwwroot
            string webRootPath = _hostingEnvironment.WebRootPath;

            // Building the path to the uploads directory
            var fileRoute = Path.Combine(webRootPath, "Uploads");

            // Get the mime type
            var mimeType = HttpContext.Request.Form.Files.GetFile("file").ContentType;

            // Get File Extension
            string extension = System.IO.Path.GetExtension(theFile.FileName);

            // Generate Random name.
            string name = Guid.NewGuid().ToString().Substring(0, 8) + extension;

            // Build the full path inclunding the file name
            string link = Path.Combine(fileRoute, name);

            // Create directory if it does not exist.
            FileInfo dir = new FileInfo(fileRoute);
            dir.Directory.Create();

            // Basic validation on mime types and file extension
            string[] imageMimetypes =
                {"image/gif", "image/jpeg", "image/pjpeg", "image/x-png", "image/png", "image/svg+xml"};
            string[] imageExt = { ".gif", ".jpeg", ".jpg", ".png", ".svg", ".blob" };

            try
            {
                if (Array.IndexOf(imageMimetypes, mimeType) >= 0 && (Array.IndexOf(imageExt, extension) >= 0))
                {
                    // Copy contents to memory stream.
                    Stream stream;
                    stream = new MemoryStream();
                    await theFile.CopyToAsync(stream);
                    stream.Position = 0;
                    var serverPath = link;

                    // Save the file
                    await using (FileStream writerFileStream = System.IO.File.Create(serverPath))
                    {
                        await stream.CopyToAsync(writerFileStream);
                        await writerFileStream.DisposeAsync();
                    }

                    // Return the file path as json
                    Hashtable imageUrl = new Hashtable();
                    imageUrl.Add("link", "/Uploads/" + name);

                    return Json(imageUrl);
                }

                throw new ArgumentException("The image did not pass the validation");
            }

            catch (ArgumentException ex)
            {
                return Json(ex.Message);
            }
        }


        [HttpPost]
        [Route("file-upload")]
        public async Task<IActionResult> UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;
            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName);
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/Uploads",
                fileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await upload.CopyToAsync(stream);
            }
            var url = $"/Uploads/{fileName}";
            return Json(new { uploaded = true, url });
        }
    }
}
