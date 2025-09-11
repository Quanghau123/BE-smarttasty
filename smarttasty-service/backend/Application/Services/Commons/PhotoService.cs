using backend.Infrastructure.Configurations;
using backend.Application.Interfaces.Commons;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Application.Services.Commons
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService(IOptions<CloudinarySettings> cloudinarySettings)
        {
            var acc = new Account(
                cloudinarySettings.Value.CloudName,
                cloudinarySettings.Value.ApiKey,
                cloudinarySettings.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc) { Api = { Secure = true } };
        }

        public async Task<string?> UploadPhotoAsync(IFormFile file, string folder)
        {
            try
            {
                if (file == null || file.Length == 0) return null;

                var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                if (!allowedExtensions.Contains(ext)) throw new Exception("Invalid file type");

                if (file.Length > 5 * 1024 * 1024) throw new Exception("File too large. Max 5MB");

                await using var stream = file.OpenReadStream();

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = folder,
                    Transformation = new Transformation().Width(1024).Height(1024).Crop("limit")
                };

                var result = await _cloudinary.UploadAsync(uploadParams);
                if (result.Error != null) throw new Exception(result.Error.Message);

                return result.PublicId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UploadPhotoAsync ERROR] {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeletePhotoAsync(string publicId)
        {
            try
            {
                var deleteParams = new DeletionParams(publicId) { Invalidate = true };
                var result = await _cloudinary.DestroyAsync(deleteParams);

                return result.Result == "ok" || result.Result == "not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DeletePhotoAsync ERROR] {ex.Message}");
                return false;
            }
        }
    }
}
