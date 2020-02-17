using System;
using System.Security.Cryptography;
using System.Text;

namespace Sorschia.Security
{
    public static class CryptoHash
    {
        private static string ExtractString(byte[] hashBytes)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("X2"));
            }

            return builder.ToString();
        }

        private static string HashBase<T>(Func<T> createAlgorithm, string value)
            where T : HashAlgorithm
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var bytes = Encoding.UTF8.GetBytes(value);
                using (var algorithm = createAlgorithm())
                {
                    var hashBytes = algorithm.ComputeHash(bytes);
                    return ExtractString(hashBytes);
                }
            }
            else
            {
                return default;
            }
        }

        public static string ComputeSHA256(string value)
        {
            return HashBase(SHA256.Create, value);
        }

        public static string ComputeSHA512(string value)
        {
            return HashBase(SHA512.Create, value);
        }
    }
}
