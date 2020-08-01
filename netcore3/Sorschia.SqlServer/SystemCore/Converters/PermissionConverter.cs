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

        private readonly IFieldNameCache _fieldNameCache;

        public PermissionConverter(IFieldNameCache fieldNameCache)
        {
            _fieldNameCache = fieldNameCache;
        }

        public Permission Convert(SqlDataReader reader) => new Permission
        {
            Id = reader.GetInt32(FIELD_ID, _fieldNameCache),
            Description = reader.GetString(FIELD_DESCRIPTION, _fieldNameCache),
            GroupId = reader.GetNullableInt32(FIELD_GROUPID, _fieldNameCache),
            IsApiPermission = reader.GetBoolean(FIELD_ISAPIPERMISSION, _fieldNameCache),
            ApiDomain = reader.GetString(FIELD_APIDOMAIN, _fieldNameCache),
            ApiController = reader.GetString(FIELD_APICONTROLLER, _fieldNameCache),
            ApiAction = reader.GetString(FIELD_APIACTION, _fieldNameCache),
            IsDatabasePermission = reader.GetBoolean(FIELD_ISDATABASEPERMISSION, _fieldNameCache),
            DatabaseSchema = reader.GetString(FIELD_DATABASESCHEMA, _fieldNameCache),
            DatabaseProcedure = reader.GetString(FIELD_DATABASEPROCEDURE, _fieldNameCache)
        };
    }
}
