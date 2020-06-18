using System.Security.Cryptography;

namespace Sorschia.Security
{
    public static class RandomByteArrayGenerator
    {
        public static byte[] Generate(int size)
        {
            var result = new byte[size];

            using (var provider = new RNGCryptoServiceProvider())
                provider.GetBytes(result);

            return result;
        }
    }
}
