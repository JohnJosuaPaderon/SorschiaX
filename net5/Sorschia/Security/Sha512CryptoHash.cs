using System.Security.Cryptography;

namespace Sorschia.Security
{
    internal sealed class Sha512CryptoHash : CryptoHashBase, ISha512CryptoHash
    {
        public Sha512CryptoHash() : base(SHA512.Create())
        {
        }
    }
}
