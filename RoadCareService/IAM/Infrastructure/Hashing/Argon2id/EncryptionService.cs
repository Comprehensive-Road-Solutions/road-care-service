using System.Security.Cryptography;
using System.Text;
using RoadCareService.IAM.Application.Internal.OutboundServices;

namespace RoadCareService.IAM.Infrastructure.Hashing.Argon2id
{
    internal class EncryptionService : IEncryptionService
    {
        public string CreateSalt()
        {
            byte[] buffer = new byte[16];

            using (RandomNumberGenerator rng = RandomNumberGenerator
                .Create()) rng.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }

        public string HashCode
            (string code, string salt)
        {
            Konscious.Security
                .Cryptography.Argon2id encryptionCode =
                new(Encoding.UTF8.GetBytes(code))
            {
                Salt = Encoding.UTF8.GetBytes(salt),
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 1024
            };

            return Convert.ToBase64String
                (encryptionCode.GetBytes(16));
        }

        public bool VerifyHash
            (string code, string salt, string hash)
        {
            string newHash = HashCode(code, salt);

            return hash.SequenceEqual(newHash);
        }
    }
}