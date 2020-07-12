namespace Sorschia.Security
{
    public sealed class RsaCryptoKeyPair
    {
        public string PrivateKeyString { get; }
        public string PublicKeyString { get; }

        public RsaCryptoKeyPair(string privateKeyString, string publicKeyString)
        {
            if (string.IsNullOrWhiteSpace(privateKeyString))
                throw new SorschiaSecurityException("Private key string is null or white-space");

            if (string.IsNullOrWhiteSpace(publicKeyString))
                throw new SorschiaSecurityException("Public key string is null or white-space");

            PrivateKeyString = privateKeyString;
            PublicKeyString = publicKeyString;
        }
    }
}
