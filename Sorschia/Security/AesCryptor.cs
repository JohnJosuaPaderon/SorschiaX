using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Sorschia.Security
{
    internal sealed class AesCryptor : ICryptor
    {
        private readonly int _keySize = 16;
        private readonly int _derivationIterations = 10_000;
        private readonly Encoding _encoding = Encoding.UTF8;

        private void ValidatePlainText(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
            {
                throw new SorschiaSecurityException($"Parameter '{nameof(plainText)}' cannot be null or white space.");
            }
        }

        private void ValidateCipherText(string cipherText)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
            {
                throw new SorschiaSecurityException($"Parameter '{nameof(cipherText)}' cannot be null or white space.");
            }
        }

        private void ValidateCryptoKey(string cryptoKey)
        {
            if (string.IsNullOrWhiteSpace(cryptoKey))
            {
                throw new SorschiaSecurityException($"Parameter '{nameof(cryptoKey)}' cannot be null or white space.");
            }
        }

        private void ValidateSalt(byte[] salt)
        {
            if (salt == null || salt.Length <= 0)
            {
                throw new SorschiaSecurityException($"Parameter '{nameof(salt)}' cannot be null or empty array.");
            }
        }

        private void ValidateIv(byte[] iv)
        {
            if (iv == null || iv.Length <= 0)
            {
                throw new SorschiaSecurityException($"Parameter '{nameof(iv)}' cannot be null or empty array.");
            }
        }

        private void CompareSalt(byte[] left, byte[] right)
        {
            ValidateSalt(left);
            ValidateSalt(right);

            if (!left.SequenceEqual(right))
            {
                throw new SorschiaSecurityException("Salts mismatched");
            }
        }

        private void CompareIv(byte[] left, byte[] right)
        {
            ValidateIv(left);
            ValidateIv(right);

            if (!left.SequenceEqual(right))
            {
                throw new SorschiaSecurityException("IVs mismatched");
            }
        }

        public string Encrypt(string plainText, string cryptoKey)
        {
            return Encrypt(plainText, cryptoKey, RandomBytes.Generate(_keySize), RandomBytes.Generate(_keySize));
        }

        public string Encrypt(string plainText, string cryptoKey, byte[] salt, byte[] iv)
        {
            ValidatePlainText(plainText);
            ValidateCryptoKey(cryptoKey);
            ValidateSalt(salt);
            ValidateIv(iv);

            var bytes = _encoding.GetBytes(plainText);

            using (var rfc2898DeriveBytes = GetCryptoKeyRfc2898DeriveBytes(cryptoKey, salt))
            {
                using (var algorithm = InitializeAlgorithm())
                {
                    using (var encryptor = algorithm.CreateEncryptor(GetCryptoKeyBytes(rfc2898DeriveBytes), iv))
                    {
                        using (var stream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(bytes, 0, bytes.Length);
                                cryptoStream.FlushFinalBlock();

                                var resultBytes = salt.Concat(iv).Concat(stream.ToArray());
                                return Convert.ToBase64String(resultBytes.ToArray());
                            }
                        }
                    }
                }
            }
        }

        public string Encrypt(string plainText, string cryptoKey, out byte[] salt, out byte[] iv)
        {
            salt = RandomBytes.Generate(_keySize);
            iv = RandomBytes.Generate(_keySize);
            return Encrypt(plainText, cryptoKey, salt, iv);
        }

        public string Decrypt(string cipherText, string cryptoKey)
        {
            ValidateCipherText(cipherText);
            ValidateCryptoKey(cryptoKey);

            var bytes = Convert.FromBase64String(cipherText);
            var salt = bytes.Take(_keySize).ToArray();
            var iv = bytes.Skip(_keySize).Take(_keySize).ToArray();
            bytes = bytes.Skip(_keySize * 2).Take(bytes.Length - (_keySize * 2)).ToArray();

            using (var rfc2898DeriveBytes = GetCryptoKeyRfc2898DeriveBytes(cryptoKey, salt))
            {
                using (var algorithm = InitializeAlgorithm())
                {
                    using (var decryptor = algorithm.CreateDecryptor(GetCryptoKeyBytes(rfc2898DeriveBytes), iv))
                    {
                        using (var stream = new MemoryStream(bytes))
                        {
                            using (var cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                            {
                                var resultBytes = new byte[bytes.Length];
                                var resultBytesCount = cryptoStream.Read(resultBytes, 0, resultBytes.Length);
                                return _encoding.GetString(resultBytes, 0, resultBytesCount);
                            }
                        }
                    }
                }
            }
        }

        public string Decrypt(string cipherText, string cryptoKey, byte[] salt, byte[] iv)
        {
            ValidateCipherText(cipherText);
            ValidateCryptoKey(cryptoKey);

            var bytes = Convert.FromBase64String(cipherText);
            var keySalt = bytes.Take(_keySize).ToArray();
            var keyIv = bytes.Skip(_keySize).Take(_keySize).ToArray();

            CompareSalt(keySalt, salt);
            CompareIv(keyIv, iv);

            bytes = bytes.Skip(_keySize * 2).Take(bytes.Length - (_keySize * 2)).ToArray();

            using (var rfc2898DeriveBytes = GetCryptoKeyRfc2898DeriveBytes(cryptoKey, keySalt))
            {
                using (var algorithm = InitializeAlgorithm())
                {
                    using (var decryptor = algorithm.CreateDecryptor(GetCryptoKeyBytes(rfc2898DeriveBytes), keyIv))
                    {
                        using (var stream = new MemoryStream(bytes))
                        {
                            using (var cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                            {
                                var resultBytes = new byte[bytes.Length];
                                var resultBytesCount = cryptoStream.Read(resultBytes, 0, resultBytes.Length);
                                return _encoding.GetString(resultBytes, 0, resultBytesCount);
                            }
                        }
                    }
                }
            }
        }

        private Rfc2898DeriveBytes GetCryptoKeyRfc2898DeriveBytes(string cryptoKey, byte[] salt)
        {
            return new Rfc2898DeriveBytes(cryptoKey, salt, _derivationIterations);
        }

        private byte[] GetCryptoKeyBytes(Rfc2898DeriveBytes rfc2898DeriveBytes)
        {
            return rfc2898DeriveBytes.GetBytes(_keySize);
        }

        private RijndaelManaged InitializeAlgorithm()
        {
            return new RijndaelManaged
            {
                BlockSize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };
        }
    }
}
