using Microsoft.AspNetCore.Http;

namespace a5pwt_ctvrtek.Domain.Services.Files
{
    public interface IFileHandler
    {
        string SaveImage(IFormFile file);
    }
}
