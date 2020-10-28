using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sorschia.Security
{
    internal sealed class RsaCrypto : IRsaCrypto
    {
        private readonly Encoding _utf8 = Encoding.UTF8;
        private readonly Pkcs1Encoding _pkcs1 = new Pkcs1Encoding(new RsaEngine());
        private readonly PemStringConverter _pemStringConverter;

        public RsaCrypto(PemStringConverter pemStringConverter)
        {
            _pemStringConverter = pemStringConverter;
        }

        public byte[] Encrypt(byte[] data, string publicKeyString)
        {
            ValidateBuffer(data);
            return ProcessCrypto(data, 0, data.Length, _pemStringConverter.ToPublicKey(publicKeyString));
        }

        public string Encrypt(string text, string publicKeyString) => text == null ? null : Convert.ToBase64String(Encrypt(_utf8.GetBytes(text), publicKeyString));

        public byte[] Decrypt(byte[] cipherData, string privateKeyString)
        {
            ValidateBuffer(cipherData);
            return ProcessCrypto(cipherData, 0, cipherData.Length, _pemStringConverter.ToPrivateKey(privateKeyString));
        }

        public string Decrypt(string cipherText, string privateKeyString) => cipherText == null ? null : _utf8.GetString(Decrypt(Convert.FromBase64String(cipherText), privateKeyString));

        private byte[] ProcessCrypto(byte[] buffer, int offset, int length, AsymmetricKeyParameter key)
        {
            _pkcs1.Init(!key.IsPrivate, key);
            var blockSize = _pkcs1.GetInputBlockSize();
            var result = new List<byte>();

            for (int i = offset; i < offset + length; i += blockSize)
            {
                var currentSize = Math.Min(blockSize, offset + length - i);
                result.AddRange(_pkcs1.ProcessBlock(buffer, i, currentSize));
            }

            return result.ToArray();
        }

        private void ValidateBuffer(byte[] buffer)
        {
            if (buffer is null)
                throw new SorschiaSecurityException("Invalid buffer");

            if (buffer.Length <= 0)
                throw new SorschiaSecurityException("Invalid buffer length");
        }
    }
}
