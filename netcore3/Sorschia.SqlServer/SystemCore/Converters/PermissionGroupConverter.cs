using Sorschia.Converters;
using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Converters
{
    internal sealed class PermissionGroupConverter : IReaderConverter<PermissionGroup>
    {
        private const string FIELD_ID = "[Id]";
        private const string FIELD_NAME = "[Name]";
        private const string FIELD_PARENTID = "[ParentId]";

        public PermissionGroup Convert(SqlDataReader reader) => new PermissionGroup
        {
            Id = reader.GetInt32(FIELD_ID),
            Name = reader.GetString(FIELD_NAME),
            ParentId = reader.GetNullableInt32(FIELD_PARENTID)
        };
    }
}
