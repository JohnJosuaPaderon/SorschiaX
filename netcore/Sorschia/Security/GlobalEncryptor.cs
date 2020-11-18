namespace Sorschia.Security
{
    internal sealed class GlobalEncryptor : IGlobalEncryptor
    {
        private readonly IRsaCrypto _crypto;
        private readonly IGlobalCryptoPublicKeyProvider _keyProvider;

        public GlobalEncryptor(IRsaCrypto crypto, IGlobalCryptoPublicKeyProvider keyProvider)
        {
            _crypto = crypto;
            _keyProvider = keyProvider;
        }

        public string Encrypt(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return _crypto.Encrypt(text, _keyProvider.Request());
        }
    }
}
