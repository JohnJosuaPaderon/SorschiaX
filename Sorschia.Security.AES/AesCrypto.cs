using System;

namespace Sorschia.Security
{
    internal sealed class AesCrypto : ISymmetricCrypto
    {
        private readonly byte[] _keyBytes;

        public AesCrypto(byte[] keyBytes)
        {
            _keyBytes = keyBytes;
        }

        public byte[] Decrypt(byte[] cipherBytes)
        {
            throw new NotImplementedException();
        }

        public byte[] Encrypt(byte[] plainBytes)
        {
            throw new NotImplementedException();
        }
    }
}
