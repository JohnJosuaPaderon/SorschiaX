using Sorschia.Security;

namespace Sorschia.SystemCore
{
    internal sealed class UserPasswordDecryptor : IUserPasswordDecryptor
    {
        private readonly IRsaCrypto _crypto;
        private readonly IUserPasswordPrivateKeyProvider _keyProvider;

        public UserPasswordDecryptor(IRsaCrypto crypto, IUserPasswordPrivateKeyProvider keyProvider)
        {
            _crypto = crypto;
            _keyProvider = keyProvider;
        }

        public string Decrypt(string cipherPassword)
        {
            if (string.IsNullOrWhiteSpace(cipherPassword))
                return null;

            return _crypto.Decrypt(cipherPassword, _keyProvider.Request());
        }
    }
}
