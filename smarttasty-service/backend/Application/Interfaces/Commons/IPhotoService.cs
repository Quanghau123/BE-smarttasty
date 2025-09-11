using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace backend.Application.Interfaces.Commons
{
    public interface IPhotoService
    {
        Task<string?> UploadPhotoAsync(IFormFile file, string folder);
        Task<bool> DeletePhotoAsync(string publicId);
    }
}
