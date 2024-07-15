namespace RoadCareService.IAM.Infrastructure.Token.JWT.Configuration
{
    public class JwtSettings
    {
        public string JWT_SECRET_KEY { get; set; }
        public string JWT_AUDIENCE_TOKEN { get; set; }
        public string JWT_ISSUER_TOKEN { get; set; }
        public int JWT_EXPIRE_MINUTES { get; set; }

        public JwtSettings()
        {
            JWT_SECRET_KEY = string.Empty;
            JWT_AUDIENCE_TOKEN = string.Empty;
            JWT_ISSUER_TOKEN = string.Empty;
            JWT_EXPIRE_MINUTES = 0;
        }
    }
}