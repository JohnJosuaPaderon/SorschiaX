using Sorschia.Converters;
using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Converters
{
    internal sealed class PermissionConverter : IReaderConverter<Permission>
    {
        private const string FIELD_ID = "[Id]";
        private const string FIELD_DESCRIPTION = "[Description]";
        private const string FIELD_GROUPID = "[GroupId]";

        public Permission Convert(SqlDataReader reader) => new Permission
        {
            Id = reader.GetInt32(FIELD_ID),
            Description = reader.GetString(FIELD_DESCRIPTION),
            GroupId = reader.GetNullableInt32(FIELD_GROUPID)
        };
    }
}
