using System.Security.Cryptography;

namespace Sorschia.Security
{
    internal sealed class Md5CryptoHash : CryptoHashBase, IMd5CryptoHash
    {
        public Md5CryptoHash() : base(MD5.Create())
        {
        }
    }
}
