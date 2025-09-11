namespace backend.Infrastructure.Configurations
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = "";
        public string TokenExpiry { get; set; } = "3600";
    }
}
