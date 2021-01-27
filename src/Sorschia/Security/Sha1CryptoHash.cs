using System.Security.Cryptography;

namespace Sorschia.Security
{
    internal sealed class Sha1CryptoHash : CryptoHashBase
    {
        public Sha1CryptoHash() : base(SHA1.Create())
        {
        }
    }
}
