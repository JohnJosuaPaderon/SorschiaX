using System.Security.Cryptography;

namespace Sorschia.Security
{
    internal sealed class Sha256CryptoHash : CryptoHashBase, ISha256CryptoHash
    {
        public Sha256CryptoHash() : base(SHA256.Create())
        {
        }
    }
}
