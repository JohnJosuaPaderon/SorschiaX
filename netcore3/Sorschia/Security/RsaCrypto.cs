using System;
using System.Security.Cryptography;
using System.Text;

namespace Sorschia.Security
{
    public sealed class RsaCrypto
    {
        private readonly Encoding _utf8 = Encoding.UTF8;

        public byte[] Encrypt(byte[] data, string publicKey)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);
            return rsa.Encrypt(data, false);
        }

        public byte[] Decrypt(byte[] cipherData, string privateKey)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);
            return rsa.Decrypt(cipherData, false);
        }

        public string Encrypt(string text, string publicKey) => Convert.ToBase64String(Encrypt(_utf8.GetBytes(text), publicKey));

        public string Decrypt(string cipherText, string privateKey) => _utf8.GetString(Decrypt(Convert.FromBase64String(cipherText), privateKey));
    }
}
