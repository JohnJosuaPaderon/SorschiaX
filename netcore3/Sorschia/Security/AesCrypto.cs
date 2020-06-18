using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace Sorschia.Security
{
    public sealed partial class AesCrypto
    {
        private readonly int _keySize = 16;
        private readonly Encoding _utf8 = Encoding.UTF8;

        public EncryptionResult Encrypt(byte[] data, byte[] cryptoKey)
        {
            var result = new EncryptionResult();
            var iv = RandomByteArrayGenerator.Generate(_keySize);
            var salt = RandomByteArrayGenerator.Generate(_keySize);

            using (var algorithm = InitializeAlgorithm())
            {
                using (var encryptor = algorithm.CreateEncryptor(GetCryptoKeyWithSalt(cryptoKey, salt), iv))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        memoryStream.Write(iv, 0, iv.Length);
                        memoryStream.Write(salt, 0, salt.Length);

                        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(data, 0, data.Length);
                            cryptoStream.FlushFinalBlock();
                        }

                        result.Iv = iv;
                        result.Salt = salt;
                        result.CipherData = memoryStream.ToArray();

                        return result;
                    }
                }
            }
        }

        public EncryptionResult Encrypt(string text, string cryptoKeyString)
        {
            return Encrypt(_utf8.GetBytes(text), _utf8.GetBytes(cryptoKeyString));
        }

        public byte[] Decrypt(byte[] cipherData, byte[] cryptoKey)
        {
            var iv = cipherData.Take(_keySize).ToArray();
            var salt = cipherData.Skip(iv.Length).Take(_keySize).ToArray();
            cipherData = cipherData.Skip(iv.Length + salt.Length).ToArray();

            using (var algorithm = InitializeAlgorithm())
            {
                using (var decryptor = algorithm.CreateDecryptor(GetCryptoKeyWithSalt(cryptoKey, salt), iv))
                {
                    using (var memoryStream = new MemoryStream(cipherData))
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            var result = new byte[cipherData.Length];
                            cryptoStream.Read(result, 0, cipherData.Length);
                            return result;
                        }
                    }
                }
            }
        }

        public string Decrypt(string cipherText, string cryptoKeyString)
        {
            var utf8 = Encoding.UTF8;
            return utf8.GetString(Decrypt(Convert.FromBase64String(cipherText), utf8.GetBytes(cryptoKeyString)));
        }

        private Aes InitializeAlgorithm()
        {
            var algorithm = AesCryptoServiceProvider.Create();
            algorithm.Mode = CipherMode.CBC;
            algorithm.Padding = PaddingMode.PKCS7;
            return algorithm;
        }

        private byte[] GetCryptoKeyWithSalt(byte[] cryptoKey, byte[] salt)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(cryptoKey, salt, 10_000))
            {
                return rfc2898DeriveBytes.GetBytes(_keySize);
            }
        }
    }
}
