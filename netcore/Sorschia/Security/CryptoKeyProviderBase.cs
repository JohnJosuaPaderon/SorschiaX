namespace Sorschia.Security
{
    internal abstract class CryptoKeyProviderBase
    {
        private readonly object _lockObj = new object();
        private readonly IKeyStringReader _reader;
        private readonly IKeyStringWriter _writer;
        private string KeyString { get; set; }

        public CryptoKeyProviderBase(IKeyStringReader reader, IKeyStringWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Register(string keyString)
        {
            lock (_lockObj)
            {
                _writer.Write(keyString);
                KeyString = keyString;
            }
        }

        public string Request()
        {
            lock (_lockObj)
            {
                if (KeyString is null)
                    KeyString = _reader.Read();

                return KeyString;
            }
        }
    }
}
