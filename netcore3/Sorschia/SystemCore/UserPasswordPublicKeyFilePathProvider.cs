namespace Sorschia.SystemCore
{
    internal sealed class UserPasswordPublicKeyFilePathProvider
    {
        public UserPasswordPublicKeyFilePathProvider(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }
    }
}
