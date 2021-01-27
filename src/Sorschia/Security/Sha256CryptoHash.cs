using System.Security.Cryptography;

namespace Sorschia.Security
{
    internal sealed class Sha256CryptoHash : CryptoHashBase
    {
        public Sha256CryptoHash() : base(SHA256.Create())
        {
        }
    }
}
