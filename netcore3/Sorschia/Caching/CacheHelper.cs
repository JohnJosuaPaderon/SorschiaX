using Newtonsoft.Json;
using Sorschia.Security;
using System.Text;

namespace Sorschia.Caching
{
    internal sealed class CacheHelper : ICacheHelper
    {
        private readonly CryptoHash _cryptoHash;

        public CacheHelper(CryptoHash cryptoHash)
        {
            _cryptoHash = cryptoHash;
        }

        private string BuildKey<TModel, TResult>(TModel model) =>
            new StringBuilder($"{typeof(TModel)}@")
            .Append(Equals(model, default(TModel)) ? "~" : JsonConvert.SerializeObject(model, Formatting.None))
            .ToString();

        public string CreateKey<TModel, TResult>(TModel model) => _cryptoHash.ComputeSha512(BuildKey<TModel, TResult>(model));

        public void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new SorschiaCachingException("Cache key cannot be null or white-space");
        }
    }
}
