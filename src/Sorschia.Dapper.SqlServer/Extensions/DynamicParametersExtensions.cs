using Dapper;
using System.Collections.Generic;
using System.Data;

namespace Sorschia.Extensions
{
    public static class DynamicParametersExtensions
    {
        public static DynamicParameters AddInput(this DynamicParameters instance, string name, object value)
        {
            instance.Add(name, value);
            return instance;
        }

        public static DynamicParameters AddValueTypeInput<T>(this DynamicParameters instance, string name, string typeName, IEnumerable<T> values, string valueFieldName = "Value")
        {
            var table = new DataTable();
            table.Columns.Add(valueFieldName, typeof(T));

            if (values is not null)
            {
                foreach (var value in values)
                {
                    table.Rows.Add(value);
                }
            }

            return instance.AddInput(name, table.AsTableValuedParameter(typeName));
        }
    }
}
