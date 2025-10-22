namespace backend.Infrastructure.Configurations
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public string TokenExpiry { get; set; } = "3600";
        public bool UseRedisSessionValidation { get; set; } = false;
        public int AccessTokenExpireMinutes { get; set; } = 120;
        public int RefreshTokenExpireDays { get; set; } = 7;
    }
}
