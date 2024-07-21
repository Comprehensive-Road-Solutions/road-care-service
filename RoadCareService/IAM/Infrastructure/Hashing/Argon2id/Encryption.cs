using System.Security.Cryptography;
using System.Text;

namespace RoadCareService.IAM.Infrastructure.Hashing.Argon2id
{
    public class Encryption
    {
        public string CreateSalt()
        {
            byte[] buffer = new byte[16];

            RNGCryptoServiceProvider random = new();

            random.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }

        public string HashCode(string code, string salt)
        {
            Konscious.Security.Cryptography.Argon2id EncryptionCode =
                new(Encoding.UTF8.GetBytes(code))
            {
                Salt = Encoding.UTF8.GetBytes(salt),
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 1024
            };

            return Convert.ToBase64String(EncryptionCode.GetBytes(16));
        }

        public bool VerifyHash(string code, string salt, string hash)
        {
            string newHash = HashCode(code, salt);

            return hash.SequenceEqual(newHash);
        }
    }
}