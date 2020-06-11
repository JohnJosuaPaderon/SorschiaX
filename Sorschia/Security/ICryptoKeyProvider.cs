namespace Sorschia.Security
{
    public interface ICryptoKeyProvider
    {
        byte[] this[string identifier] { get; set; }
    }
}
