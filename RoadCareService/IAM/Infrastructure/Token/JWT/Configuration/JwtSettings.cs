namespace RoadCareService.IAM.Infrastructure.Token.JWT.Configuration
{
    internal class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Expire { get; set; }

        public JwtSettings()
        {
            SecretKey = string.Empty;
            Audience = string.Empty;
            Issuer = string.Empty;
            Expire = 0;
        }
    }
}