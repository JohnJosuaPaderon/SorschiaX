namespace Sorschia.Caching
{
    public interface ICacheHelper
    {
        void ValidateKey(string key);
        string CreateKey<TModel, TResult>(TModel model);
    }
}
