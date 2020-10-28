namespace Sorschia.SystemCore
{
    internal sealed class UserPasswordPublicKeyProvider : IUserPasswordPublicKeyProvider
    {
        private readonly IUserPasswordPublicKeyReader _reader;
        private readonly IUserPasswordPublicKeyWriter _writer;
        private readonly object _lockObj = new object();
        private string PublicKeyString { get; set; }

        public UserPasswordPublicKeyProvider(IUserPasswordPublicKeyReader reader, IUserPasswordPublicKeyWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Register(string keyString)
        {
            lock (_lockObj)
            {
                _writer.WriteString(keyString);
                PublicKeyString = keyString;
            }
        }

        public string Request()
        {
            lock (_lockObj)
            {
                if (PublicKeyString is null)
                {
                    PublicKeyString = _reader.ReadString();
                }

                return PublicKeyString;
            }
        }
    }
}
