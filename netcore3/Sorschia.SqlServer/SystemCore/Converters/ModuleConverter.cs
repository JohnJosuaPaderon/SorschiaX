using Sorschia.Converters;
using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Converters
{
    internal sealed class ModuleConverter : IReaderConverter<Module>
    {
        private const string FIELD_ID = "[Id]";
        private const string FIELD_NAME = "[Name]";
        private const string FIELD_ORDINALNUMBER = "[OrdinalNumber]";
        private const string FIELD_APPLICATIONID = "[ApplicationId]";
        private const string FIELD_ROUTEURL = "[RouteUrl]";

        private readonly IFieldNameCache _fieldNameCache;

        public ModuleConverter(IFieldNameCache fieldNameCache)
        {
            _fieldNameCache = fieldNameCache;
        }

        public Module Convert(SqlDataReader reader) => new Module
        {
            Id = reader.GetInt32(FIELD_ID, _fieldNameCache),
            Name = reader.GetString(FIELD_NAME, _fieldNameCache),
            OrdinalNumber = reader.GetInt32(FIELD_ORDINALNUMBER, _fieldNameCache),
            ApplicationId = reader.GetNullableInt32(FIELD_APPLICATIONID, _fieldNameCache),
            RouteUrl = reader.GetString(FIELD_ROUTEURL, _fieldNameCache)
        };
    }
}
