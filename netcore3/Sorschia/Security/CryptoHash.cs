using System;
using System.Security.Cryptography;
using System.Text;

namespace Sorschia.Security
{
    public sealed class CryptoHash
    {
        private readonly Encoding _utf8 = Encoding.UTF8;

        private string ToString(byte[] output) => output != default && output.Length > 0 ? new StringBuilder(BitConverter.ToString(output)).Replace("-", string.Empty).ToString() : default;

        private byte[] ComputeHash<THashAlgorithm>(Func<THashAlgorithm> createAlgorithm, byte[] input)
            where THashAlgorithm : HashAlgorithm
        {
            if (input == default || input.Length <= 0)
                return default;

            using (var algorithm = createAlgorithm())
                return algorithm.ComputeHash(input);
        }

        private string ComputeHash<THashAlgorithm>(Func<THashAlgorithm> createAlgorithm, string input)
            where THashAlgorithm : HashAlgorithm => ToString(ComputeHash<THashAlgorithm>(createAlgorithm, _utf8.GetBytes(input)));

        public byte[] ComputeSha256(byte[] input) => ComputeHash(SHA256.Create, input);

        public byte[] ComputeSha512(byte[] input) => ComputeHash(SHA512.Create, input);

        public string ComputeSha256(string input) => ComputeHash(SHA256.Create, input);

        public string ComputeSha512(string input) => ComputeHash(SHA512.Create, input);
    }
}
