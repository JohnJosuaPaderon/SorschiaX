using System.Collections.Generic;
using System.Security.Cryptography;

namespace Sorschia.Security
{
    internal sealed class RsaPrivateKeyStore : IRsaPrivateKeyStore
    {
        private readonly object _lock = new object();
        private readonly IDictionary<string, string> _store = new Dictionary<string, string>();
        private readonly CryptoHash _cryptoHash = new CryptoHash();
        private readonly IRsaPublicKeyStore _publicKeyStore;

        public RsaPrivateKeyStore(IRsaPublicKeyStore publicKeyStore)
        {
            _publicKeyStore = publicKeyStore;
        }

        public RsaKeys Initialize(string purpose)
        {
            lock (_lock)
            {
                var purposeHash = ComputePurposeHash(purpose);
                if (_store.ContainsKey(purposeHash))
                    throw new SorschiaSecurityException($"Private Key with purpose '{purpose}' already exists");

                using var rsa = new RSACryptoServiceProvider();
                var privateKey = rsa.ToXmlString(true);
                var publicKey = rsa.ToXmlString(false);

                _store.Add(purposeHash, privateKey);
                _publicKeyStore.Register(purpose, publicKey);

                return new RsaKeys(privateKey, publicKey);
            }
        }

        public string Request(string purpose)
        {
            lock (_lock)
            {
                var purposeHash = ComputePurposeHash(purpose);
                if (!_store.ContainsKey(purposeHash))
                    throw new SorschiaSecurityException($"Private Key with purpose '{purpose}' doesn't exists");

                return _store[purposeHash];
            }
        }

        private string ComputePurposeHash(string purpose) => _cryptoHash.ComputeSha512($"SORSCHIA[PRIVATE_KEY]:{purpose}");
    }
}
