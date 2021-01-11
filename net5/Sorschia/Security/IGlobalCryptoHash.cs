namespace Sorschia.Security
{
    public interface IGlobalCryptoHash
    {
        string? Compute(string? text);
    }
}
