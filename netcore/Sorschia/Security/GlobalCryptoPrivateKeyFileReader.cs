using Sorschia.IO;

namespace Sorschia.Security
{
    internal sealed class GlobalCryptoPrivateKeyFileReader : StringFileReaderBase, IGlobalCryptoPrivateKeyReader
    {
        public GlobalCryptoPrivateKeyFileReader(GlobalCryptoPrivateKeyFilePathProvider filePathProvider) : base(filePathProvider)
        {
        }
    }
}
