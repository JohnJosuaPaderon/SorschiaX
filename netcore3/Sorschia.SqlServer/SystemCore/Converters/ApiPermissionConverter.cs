using Sorschia.Converters;
using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Converters
{
    internal sealed class ApiPermissionConverter : IReaderConverter<ApiPermission>
    {
        private const string FIELD_ID = "[Id]";
        private const string FIELD_DESCRIPTION = "[Description]";
        private const string FIELD_TYPEID = "[TypeId]";
        private const string FIELD_GROUPID = "[GroupId]";
        private const string FIELD_CONTROLLER = "[Controller]";
        private const string FIELD_ACTION = "[Action]";

        public ApiPermission Convert(SqlDataReader reader) => new ApiPermission
        {
            Id = reader.GetInt32(FIELD_ID),
            Description = reader.GetString(FIELD_DESCRIPTION),
            TypeId = reader.GetNullableInt32(FIELD_TYPEID),
            GroupId = reader.GetNullableInt32(FIELD_GROUPID),
            Controller = reader.GetString(FIELD_CONTROLLER),
            Action = reader.GetString(FIELD_ACTION)
        };
    }
}
