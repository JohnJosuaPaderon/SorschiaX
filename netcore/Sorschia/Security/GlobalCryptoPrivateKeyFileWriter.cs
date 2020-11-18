using Sorschia.IO;

namespace Sorschia.Security
{
    internal sealed class GlobalCryptoPrivateKeyFileWriter : StringFileWriterBase, IGlobalCryptoPrivateKeyWriter
    {
        public GlobalCryptoPrivateKeyFileWriter(GlobalCryptoPrivateKeyFilePathProvider filePathProvider) : base(filePathProvider)
        {
        }
    }
}
