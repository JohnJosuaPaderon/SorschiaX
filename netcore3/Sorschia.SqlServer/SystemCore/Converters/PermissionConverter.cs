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
        private const string FIELD_ISAPIPERMISSION = "[IsApiPermission]";
        private const string FIELD_APIDOMAIN = "[ApiDomain]";
        private const string FIELD_APICONTROLLER = "[ApiController]";
        private const string FIELD_APIACTION = "[ApiAction]";
        private const string FIELD_ISDATABASEPERMISSION = "[IsDatabasePermission]";
        private const string FIELD_DATABASESCHEMA = "[DatabaseSchema]";
        private const string FIELD_DATABASEPROCEDURE = "[DatabaseProcedure]";

        public Permission Convert(SqlDataReader reader) => new Permission
        {
            Id = reader.GetInt32(FIELD_ID),
            Description = reader.GetString(FIELD_DESCRIPTION),
            GroupId = reader.GetNullableInt32(FIELD_GROUPID),
            IsApiPermission = reader.GetBoolean(FIELD_ISAPIPERMISSION),
            ApiDomain = reader.GetString(FIELD_APIDOMAIN),
            ApiController = reader.GetString(FIELD_APICONTROLLER),
            ApiAction = reader.GetString(FIELD_APIACTION),
            IsDatabasePermission = reader.GetBoolean(FIELD_ISDATABASEPERMISSION),
            DatabaseSchema = reader.GetString(FIELD_DATABASESCHEMA),
            DatabaseProcedure = reader.GetString(FIELD_DATABASEPROCEDURE)
        };
    }
}
