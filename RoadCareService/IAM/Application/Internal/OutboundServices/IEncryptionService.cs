namespace RoadCareService.IAM.Application.Internal.OutboundServices
{
    public interface IEncryptionService
    {
        string CreateSalt();

        string HashCode(string code, string salt);

        public bool VerifyHash(string code,
            string salt, string hash);
    }
}