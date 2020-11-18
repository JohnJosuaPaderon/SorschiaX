using System.Data.SqlClient;

namespace Sorschia.Data
{
    public abstract class SqlDataReaderConverterBase<TResult> : DataReaderConverterBase<SqlDataReader, TResult>
    {
    }
}
