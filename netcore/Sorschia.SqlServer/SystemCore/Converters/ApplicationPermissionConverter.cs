using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Converters
{
    internal sealed class ApplicationPermissionConverter : SqlDataReaderConverterBase<ApplicationPermission>
    {
        private const string APPLICATIONID = "ApplicationId";
        private const string PERMISSIONID = "PermissionId";
        private readonly IFieldNameCache _cache;
        private readonly ApplicationAsSubObjectConverter _applicationConverter;
        private readonly PermissionAsSubObjectConverter _permissionConverter;

        public ApplicationPermissionConverter(
            IFieldNameCache cache, 
            ApplicationAsSubObjectConverter applicationConverter,
            PermissionAsSubObjectConverter permissionConverter)
        {
            _cache = cache;
            _applicationConverter = applicationConverter;
            _permissionConverter = permissionConverter;
        }

        public override ApplicationPermission Convert(SqlDataReader reader) => new ApplicationPermission
        {
            Id = reader.GetInt64("Id", _cache),
            ApplicationId = reader.GetInt32(APPLICATIONID, _cache),
            PermissionId = reader.GetInt32(PERMISSIONID, _cache),
            Application = IsSubObjectIncluded("Application") ? _applicationConverter.Convert(reader.GetInt32(APPLICATIONID, _cache), reader) : null,
            Permission = IsSubObjectIncluded("Permission") ? _permissionConverter.Convert(reader.GetInt32(PERMISSIONID, _cache), reader) : null
        };
    }
}
