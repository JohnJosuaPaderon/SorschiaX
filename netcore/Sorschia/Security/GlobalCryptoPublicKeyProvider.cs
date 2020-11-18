namespace Sorschia.Security
{
    internal sealed class GlobalCryptoPublicKeyProvider : CryptoKeyProviderBase, IGlobalCryptoPublicKeyProvider
    {
        public GlobalCryptoPublicKeyProvider(IGlobalCryptoPublicKeyReader reader, IGlobalCryptoPublicKeyWriter writer) : base(reader, writer)
        {
        }
    }
}
