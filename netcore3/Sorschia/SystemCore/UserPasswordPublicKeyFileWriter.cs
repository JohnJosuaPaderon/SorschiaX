using System.IO;

namespace Sorschia.SystemCore
{
    internal sealed class UserPasswordPublicKeyFileWriter : IUserPasswordPublicKeyWriter
    {
        private readonly UserPasswordPublicKeyFilePathProvider _filePathProvider;

        public UserPasswordPublicKeyFileWriter(UserPasswordPublicKeyFilePathProvider filePathProvider)
        {
            _filePathProvider = filePathProvider;
        }

        public void WriteString(string keyString)
        {
            using var writer = new StreamWriter(_filePathProvider.FilePath);
            writer.Write(keyString);
        }
    }
}
