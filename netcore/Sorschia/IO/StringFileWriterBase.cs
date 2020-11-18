using System.IO;

namespace Sorschia.IO
{
    public abstract class StringFileWriterBase
    {
        private readonly IFilePathProvider _filePathProvider;

        public StringFileWriterBase(IFilePathProvider filePathProvider)
        {
            _filePathProvider = filePathProvider;
        }

        public void Write(string text)
        {
            using var writer = new StreamWriter(_filePathProvider.FilePath);
            writer.Write(text);
        }
    }
}
