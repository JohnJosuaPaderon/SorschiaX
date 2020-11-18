using Sorschia.IO;

namespace Sorschia.Security
{
    internal sealed class GlobalCryptoPublicKeyFilePathProvider : FilePathProviderBase, IFilePathProvider
    {
        public GlobalCryptoPublicKeyFilePathProvider(string filePath) : base(filePath)
        {
        }
    }
}
