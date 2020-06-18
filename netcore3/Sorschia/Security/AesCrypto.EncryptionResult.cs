using System;

namespace Sorschia.Security
{
    public sealed partial class AesCrypto
    {
        public sealed class EncryptionResult
        {
            internal EncryptionResult()
            {
            }

            public byte[] CipherData { get; internal set; }
            public byte[] Iv { get; internal set; }
            public byte[] Salt { get; internal set; }

            public string GetCipherText() => GetText(CipherData);
            public string GetIvText() => GetText(Iv);
            public string GetSaltText() => GetText(Salt);

            private string GetText(byte[] byteArray) => byteArray != default && byteArray.Length > 0 ? Convert.ToBase64String(byteArray) : default;
        }
    }
}
