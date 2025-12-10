using backend.Infrastructure.Configurations;

namespace backend.Infrastructure.Helpers
{
    public interface IImageHelper
    {
        string GetImageUrl(string publicId);
    }

    public class ImageHelper : IImageHelper
    {
        private readonly string _baseUrl;

        public ImageHelper(CloudinarySettings cloudinarySettings)
        {
            _baseUrl = $"https://res.cloudinary.com/{cloudinarySettings.CloudName}/image/upload/f_auto,q_auto";
        }

        public string GetImageUrl(string publicId)
        {
            return string.IsNullOrEmpty(publicId)
                ? ""
                : $"{_baseUrl}/{publicId}";
        }
    }
}
