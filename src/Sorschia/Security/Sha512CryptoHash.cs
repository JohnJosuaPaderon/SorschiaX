using System.Security.Cryptography;

namespace Sorschia.Security
{
    internal sealed class Sha512CryptoHash : CryptoHashBase
    {
        public Sha512CryptoHash() : base(SHA512.Create())
        {
        }
    }
}
