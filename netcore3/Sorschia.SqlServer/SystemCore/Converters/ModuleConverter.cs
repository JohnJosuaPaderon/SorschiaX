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

        public Module Convert(SqlDataReader reader) => new Module
        {
            Id = reader.GetInt32(FIELD_ID),
            Name = reader.GetString(FIELD_NAME),
            OrdinalNumber = reader.GetInt32(FIELD_ORDINALNUMBER),
            ApplicationId = reader.GetNullableInt32(FIELD_APPLICATIONID)
        };
    }
}
