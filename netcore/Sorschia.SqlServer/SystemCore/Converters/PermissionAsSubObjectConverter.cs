using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Converters
{
    internal sealed class PermissionAsSubObjectConverter : SqlDataReaderAsSubObjectConverterBase<Permission, int>
    {
        public override Permission Convert(int id, SqlDataReader reader, IFieldNameCache cache) => new Permission
        {
            Id = id,
            Name = reader.GetString("Permission_Name", cache),
            Description = reader.GetString("Permission_Description", cache),
            IsApiPermission = reader.GetBoolean("Permission_IsApiPermission", cache),
            ApiDomain = reader.GetString("Permission_ApiDomain", cache),
            ApiController = reader.GetString("Permission_ApiController", cache),
            ApiAction = reader.GetString("Permission_ApiAction", cache),
            IsDatabasePermission = reader.GetBoolean("Permission_IsDatabasePermission", cache),
            DatabaseSchema = reader.GetString("Permission_DatabaseSchema", cache),
            DatabaseProcedure = reader.GetString("Permission_DatabaseProcedure", cache)
        };
    }
}
