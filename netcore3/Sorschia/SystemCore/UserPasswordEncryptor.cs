using Sorschia.Security;

namespace Sorschia.SystemCore
{
    internal sealed class UserPasswordEncryptor : IUserPasswordEncryptor
    {
        private readonly IRsaCrypto _crypto;
        private readonly IUserPasswordPublicKeyProvider _keyProvider;

        public UserPasswordEncryptor(IRsaCrypto crypto, IUserPasswordPublicKeyProvider keyProvider)
        {
            _crypto = crypto;
            _keyProvider = keyProvider;
        }

        public string Encrypt(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return null;

            return _crypto.Encrypt(password, _keyProvider.Request());
        }
    }
}
