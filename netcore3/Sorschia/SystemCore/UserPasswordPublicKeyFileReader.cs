using System.IO;

namespace Sorschia.SystemCore
{
    internal sealed class UserPasswordPublicKeyFileReader : IUserPasswordPublicKeyReader
    {
        private readonly UserPasswordPublicKeyFilePathProvider _filePathProvider;

        public UserPasswordPublicKeyFileReader(UserPasswordPublicKeyFilePathProvider filePathProvider)
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
