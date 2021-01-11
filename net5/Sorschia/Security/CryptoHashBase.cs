using System.Security.Cryptography;

namespace Sorschia.Security
{
    public abstract class CryptoHashBase
    {
        private readonly HashAlgorithm _algorithm;

        public CryptoHashBase(HashAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public byte[]? Compute(byte[]? data) => 
            data is not null 
            ? _algorithm.ComputeHash(data)
            : null;
    }
}
