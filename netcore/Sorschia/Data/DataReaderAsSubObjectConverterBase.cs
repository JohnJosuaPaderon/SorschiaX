namespace Sorschia.Data
{
    public abstract class DataReaderAsSubObjectConverterBase<TDataReader, TResult, TId>
    {
        public abstract TResult Convert(TId id, TDataReader reader, IFieldNameCache cache, string prefix = null);

        protected string BuildFieldName(string prefix, string name) => $"{(prefix != null ? $"{prefix}_" : string.Empty)}_{name}";
    }
}
