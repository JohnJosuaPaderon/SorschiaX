using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Converters
{
    internal sealed class ApplicationAsSubObjectConverter : SqlDataReaderAsSubObjectConverterBase<Application, int>
    {
        public override Application Convert(int id, SqlDataReader reader, IFieldNameCache cache) => new Application
        {
            Id = id,
            Name = reader.GetString("Application_Name", cache),
            Description = reader.GetString("Application_Description", cache)
        };
    }
}
