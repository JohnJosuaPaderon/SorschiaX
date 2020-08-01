using Sorschia.Converters;
using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Converters
{
    internal sealed class ApplicationConverter : IReaderConverter<Application>
    {
        private const string FIELD_ID = "[Id]";
        private const string FIELD_NAME = "[Name]";
        private const string FIELD_PLATFORMID = "[PlatformId]";

        private readonly IFieldNameCache _fieldNameCache;

        public ApplicationConverter(IFieldNameCache fieldNameCache)
        {
            _fieldNameCache = fieldNameCache;
        }

        public Application Convert(SqlDataReader reader) => new Application
        {
            Id = reader.GetInt32(FIELD_ID, _fieldNameCache),
            Name = reader.GetString(FIELD_NAME, _fieldNameCache),
            PlatformId = reader.GetNullableInt32(FIELD_PLATFORMID, _fieldNameCache)
        };
    }
}
