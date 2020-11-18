namespace Sorschia.IO
{
    public abstract class FilePathProviderBase
    {
        public string FilePath { get; }

        public FilePathProviderBase(string filePath)
        {
            FilePath = filePath;
        }
    }
}
