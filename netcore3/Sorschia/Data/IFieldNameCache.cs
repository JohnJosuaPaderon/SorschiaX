using System.Data.Common;

namespace Sorschia.Data
{
    public interface IFieldNameCache
    {
        bool TryGet(DbDataReader reader, string fieldName, out object result);
    }
}
