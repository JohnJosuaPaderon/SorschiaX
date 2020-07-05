using System.Collections.Generic;

namespace Sorschia.Security
{
    internal sealed class RsaPublicKeyStore : IRsaPublicKeyStore
    {
        private readonly object _lock = new object();
        private IDictionary<string, string> _store = new Dictionary<string, string>();
        private readonly CryptoHash _cryptoHash = new CryptoHash();

        public void Register(string purpose, string publicKey)
        {
            lock (_lock)
            {
                var purposeHash = ComputePurposeHash(purpose);
                if (_store.ContainsKey(purposeHash))
                    throw new SorschiaSecurityException($"Public Key with purpose '{purpose}' already exists");

                _store.Add(purposeHash, publicKey);
            }
        }

        public string Request(string purpose)
        {
            lock (_lock)
            {
                var purposeHash = ComputePurposeHash(purpose);
                if (!_store.ContainsKey(purposeHash))
                    throw new SorschiaSecurityException($"Public Key with purpose '{purpose}' doesn't exists");
                return _store[purposeHash];
            }
        }

        private string ComputePurposeHash(string purpose) => _cryptoHash.ComputeSha512($"SORSCHIA[PUBLIC_KEY]:{purpose}");
    }
}
