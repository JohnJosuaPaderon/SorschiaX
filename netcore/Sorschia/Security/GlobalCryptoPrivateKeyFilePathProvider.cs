using Sorschia.IO;

namespace Sorschia.Security
{
    internal sealed class GlobalCryptoPrivateKeyFilePathProvider : FilePathProviderBase, IFilePathProvider
    {
        public GlobalCryptoPrivateKeyFilePathProvider(string filePath) : base(filePath)
        {
        }
    }
}
