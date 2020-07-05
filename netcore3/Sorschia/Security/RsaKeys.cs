namespace Sorschia.Security
{
    public sealed class RsaKeys
    {
        internal RsaKeys(string privateKey, string publicKey)
        {
            PrivateKey = privateKey;
            PublicKey = publicKey;
        }

        public string PrivateKey { get; }
        public string PublicKey { get; }
    }
}
