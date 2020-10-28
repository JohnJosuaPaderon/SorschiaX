namespace Sorschia.SystemCore
{
    internal sealed class UserPasswordPrivateKeyFilePathProvider
    {
        public UserPasswordPrivateKeyFilePathProvider(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }
    }
}
