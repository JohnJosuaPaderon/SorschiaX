namespace Sorschia.Security
{
    internal sealed class GlobalDecryptor : IGlobalDecryptor
    {
        private readonly IRsaCrypto _crypto;
        private readonly IGlobalCryptoPrivateKeyProvider _keyProvider;

        public GlobalDecryptor(IRsaCrypto crypto, IGlobalCryptoPrivateKeyProvider keyProvider)
        {
            _crypto = crypto;
            _keyProvider = keyProvider;
        }

        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
                return null;

            return _crypto.Decrypt(cipherText, _keyProvider.Request());
        }
    }
}
