using System.Security.Cryptography;

namespace Sorschia.Security
{
    internal sealed class Sha384CryptoHash : CryptoHashBase
    {
        public Sha384CryptoHash() : base(SHA384.Create())
        {
        }
    }
}
