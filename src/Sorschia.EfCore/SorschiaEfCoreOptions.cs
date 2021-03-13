using Sorschia.Data;

namespace Sorschia
{
    public sealed class SorschiaEfCoreOptions
    {
        public DataOptions Data { get; set; } = new DataOptions();

        internal SorschiaEfCoreOptions()
        {
        }
    }
}
