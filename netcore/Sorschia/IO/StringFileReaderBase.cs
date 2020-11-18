using System.IO;

namespace Sorschia.IO
{
    public abstract class StringFileReaderBase
    {
        private readonly IFilePathProvider _filePathProvider;

        public StringFileReaderBase(IFilePathProvider filePathProvider)
        {
            _filePathProvider = filePathProvider;
        }

        public string Read()
        {
            using var reader = new StreamReader(_filePathProvider.FilePath);
            return reader.ReadToEnd();
        }
    }
}
