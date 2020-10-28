using System.IO;

namespace Sorschia.SystemCore
{
    internal sealed class UserPasswordPrivateKeyFileWriter : IUserPasswordPrivateKeyWriter
    {
        private readonly UserPasswordPrivateKeyFilePathProvider _filePathProvider;

        public UserPasswordPrivateKeyFileWriter(UserPasswordPrivateKeyFilePathProvider filePathProvider)
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
