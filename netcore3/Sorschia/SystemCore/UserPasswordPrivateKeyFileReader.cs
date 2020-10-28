using System.IO;

namespace Sorschia.SystemCore
{
    internal sealed class UserPasswordPrivateKeyFileReader : IUserPasswordPrivateKeyReader
    {
        private readonly UserPasswordPrivateKeyFilePathProvider _filePathProvider;

        public UserPasswordPrivateKeyFileReader(UserPasswordPrivateKeyFilePathProvider filePathProvider)
        {
            _filePathProvider = filePathProvider;
        }

        public string ReadString()
        {
            using var reader = new StreamReader(_filePathProvider.FilePath);
            return reader.ReadToEnd();
        }
    }
}
