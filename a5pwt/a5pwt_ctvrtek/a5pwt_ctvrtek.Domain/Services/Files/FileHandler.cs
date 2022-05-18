using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace a5pwt_ctvrtek.Domain.Services.Files
{
    public class FileHandler : IFileHandler
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileHandler(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string SaveImage(IFormFile file)
        {
            var relativePath = $"images/products/{Guid.NewGuid()}.{file.ContentType.Replace("image/", string.Empty)}";
            var absolutePath = Path.Combine(_hostingEnvironment.WebRootPath, relativePath);
            using (var fileStream = new FileStream(absolutePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return $"/{relativePath}";
        }
    }
}
