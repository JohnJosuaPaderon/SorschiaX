namespace Sorschia.Security
{
    public interface ICryptoHash
    {
        byte[]? Compute(byte[]? data);
    }
}
