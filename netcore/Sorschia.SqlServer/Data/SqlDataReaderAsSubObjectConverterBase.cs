using System.Data.SqlClient;

namespace Sorschia.Data
{
    public abstract class SqlDataReaderAsSubObjectConverterBase<TResult, TId> : DataReaderAsSubObjectConverterBase<SqlDataReader, TResult, TId>
    {
    }
}
