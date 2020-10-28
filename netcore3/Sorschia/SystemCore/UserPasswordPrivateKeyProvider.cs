namespace Sorschia.SystemCore
{
    internal sealed class UserPasswordPrivateKeyProvider : IUserPasswordPrivateKeyProvider
    {
        private readonly IUserPasswordPrivateKeyReader _reader;
        private readonly IUserPasswordPrivateKeyWriter _writer;
        private readonly object _lockObj = new object();
        private string PrivateKeyString { get; set; }

        public UserPasswordPrivateKeyProvider(IUserPasswordPrivateKeyReader reader, IUserPasswordPrivateKeyWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Register(string keyString)
        {
            lock (_lockObj)
            {
                _writer.WriteString(keyString);
                PrivateKeyString = keyString;
            }
        }

        public string Request()
        {
            lock (_lockObj)
            {
                if (PrivateKeyString is null)
                {
                    PrivateKeyString = _reader.ReadString();
                }

                return PrivateKeyString;
            }
        }
    }
}
