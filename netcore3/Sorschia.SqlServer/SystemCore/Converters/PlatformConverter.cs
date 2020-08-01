using Sorschia.Converters;
using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Converters
{
    internal sealed class PlatformConverter : IReaderConverter<Platform>
    {
        private const string FIELD_ID = "[Id]";
        private const string FIELD_NAME = "[Name]";

        private readonly IFieldNameCache _fieldNameCache;

        public PlatformConverter(IFieldNameCache fieldNameCache)
        {
            _fieldNameCache = fieldNameCache;
        }

        public Platform Convert(SqlDataReader reader) => new Platform
        {
            Id = reader.GetInt32(FIELD_ID, _fieldNameCache),
            Name = reader.GetString(FIELD_NAME, _fieldNameCache)
        };
    }
}
