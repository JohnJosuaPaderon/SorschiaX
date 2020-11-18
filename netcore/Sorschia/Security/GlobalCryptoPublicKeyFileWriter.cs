using Sorschia.IO;

namespace Sorschia.Security
{
    internal sealed class GlobalCryptoPublicKeyFileWriter : StringFileWriterBase, IGlobalCryptoPublicKeyWriter
    {
        public GlobalCryptoPublicKeyFileWriter(GlobalCryptoPublicKeyFilePathProvider filePathProvider) : base(filePathProvider)
        {
        }
    }
}
