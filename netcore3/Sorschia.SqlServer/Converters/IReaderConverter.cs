using System.Data.SqlClient;

namespace Sorschia.Converters
{
    public interface IReaderConverter<T>
    {
        T Convert(SqlDataReader reader);
    }
}
