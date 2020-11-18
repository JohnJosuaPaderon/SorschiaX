using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Converters
{
    internal sealed class ApplicationConverter : SqlDataReaderConverterBase<Application>
    {
        private readonly IFieldNameCache _cache;

        public ApplicationConverter(IFieldNameCache cache)
        {
            _cache = cache;
        }

        public override Application Convert(SqlDataReader reader) => new Application
        {
            Id = reader.GetInt32("Id", _cache),
            Name = reader.GetString("Name", _cache),
            Description = reader.GetString("Description", _cache)
        };
    }

    internal sealed class ModuleConverter : SqlDataReaderConverterBase<Module>
    {
        private const string APPLICATIONID = "ApplicationId";
        private readonly IFieldNameCache _cache;
        private readonly ApplicationAsSubObjectConverter _applicationConverter;

        public ModuleConverter(IFieldNameCache cache, ApplicationAsSubObjectConverter applicationConverter)
        {
            _cache = cache;
            _applicationConverter = applicationConverter;
        }

        public override Module Convert(SqlDataReader reader) => new Module
        {
            Id = reader.GetInt32("Id", _cache),
            ApplicationId = reader.GetInt32(APPLICATIONID, _cache),
            Name = reader.GetString("Name", _cache),
            Description = reader.GetString("Description", _cache),
            AngularRouteUrl = reader.GetString("AngularRouteUrl", _cache),
            Application = IsSubObjectIncluded("Application") ? _applicationConverter.Convert(reader.GetInt32(APPLICATIONID, _cache), reader, _cache) : null
        };
    }

    internal sealed class ModuleAsSubObjectConverter : SqlDataReaderAsSubObjectConverterBase<Module, int>
    {
        public override Module Convert(int id, SqlDataReader reader, IFieldNameCache cache, string prefix = "Module") => new Module
        {
            Id = id,
            ApplicationId = reader.GetInt32(BuildFieldName(prefix, "Application"))
        };
    }

    internal sealed class ModulePermissionConverter : SqlDataReaderConverterBase<ModulePermission>
    {
        private readonly IFieldNameCache _cache;

        public ModulePermissionConverter(IFieldNameCache cache)
        {
            _cache = cache;
        }

        public override ModulePermission Convert(SqlDataReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}
