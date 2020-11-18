using Sorschia.IO;

namespace Sorschia.Security
{
    internal sealed class GlobalCryptoPublicKeyFileReader : StringFileReaderBase, IGlobalCryptoPublicKeyReader
    {
        public GlobalCryptoPublicKeyFileReader(GlobalCryptoPublicKeyFilePathProvider filePathProvider) : base(filePathProvider)
        {
        }
    }
}
