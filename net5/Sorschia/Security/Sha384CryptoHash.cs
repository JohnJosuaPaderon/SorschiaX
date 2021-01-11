using System.Security.Cryptography;

namespace Sorschia.Security
{
    internal sealed class Sha384CryptoHash : CryptoHashBase, ISha384CryptoHash
    {
        public Sha384CryptoHash() : base(SHA384.Create())
        {
        }
    }
}
