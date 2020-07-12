namespace Sorschia.SystemCore
{
    internal sealed class UserPasswordCryptoTransformer : IUserPasswordCryptoTransformer
    {
        private readonly IUserPasswordCryptoHash _cryptoHash;
        private readonly IUserPasswordDecryptor _decryptor;

        public UserPasswordCryptoTransformer(IUserPasswordCryptoHash cryptoHash, IUserPasswordDecryptor decryptor)
        {
            _cryptoHash = cryptoHash;
            _decryptor = decryptor;
        }

        public string ComputeHash(string cipherPassword)
        {
            if (string.IsNullOrWhiteSpace(cipherPassword))
                throw SorschiaException.InvalidParameter<string>(nameof(cipherPassword));

            return _cryptoHash.ComputeHash(_decryptor.Decrypt(cipherPassword));
        }
    }
}
