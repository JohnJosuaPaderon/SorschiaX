namespace Sorschia.Utilities
{
    public interface IObjectCopier
    {
        T Copy<T>(T source);
    }
}
