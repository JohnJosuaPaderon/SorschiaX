using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sorschia
{
    public static class SQLCommandExtensions
    {
        public static SqlCommand AddInParameter(this SqlCommand instance, string name, object value)
        {
            instance.Parameters.AddIn(name, value ?? DBNull.Value);
            return instance;
        }

        public static SqlCommand AddInParameter(this SqlCommand instance, string name, object value, SqlDbType sqlDbType)
        {
            instance.Parameters.AddIn(name, value ?? DBNull.Value, sqlDbType);
            return instance;
        }

        public static SqlCommand AddOutParameter(this SqlCommand instance, string name, SqlDbType sqlDbType)
        {
            instance.Parameters.AddOut(name, sqlDbType);
            return instance;
        }

        public static SqlCommand AddOutParameter(this SqlCommand instance, string name, SqlDbType sqlDbType, int size)
        {
            instance.Parameters.AddOut(name, sqlDbType, size);
            return instance;
        }

        public static SqlCommand AddInOutParameter(this SqlCommand instance, string name, object value, SqlDbType sqlDbType)
        {
            instance.Parameters.AddInOut(name, value ?? DBNull.Value, sqlDbType);
            return instance;
        }

        public static SqlCommand AddInOutParameter(this SqlCommand instance, string name, object value, SqlDbType sqlDbType, int size)
        {
            instance.Parameters.AddInOut(name, value ?? DBNull.Value, sqlDbType, size);
            return instance;
        }

        public static SqlCommand AddIntListParameter(this SqlCommand command, string parameterName, IEnumerable<int> intList, string fieldName = "Value", string typeName = "dbo.IntList", ParameterDirection direction = ParameterDirection.Input)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn(fieldName, typeof(int)));

            foreach (var value in intList)
            {
                dataTable.Rows.Add(value);
            }

            var parameter = new SqlParameter()
            {
                ParameterName = parameterName,
                TypeName = typeName,
                SqlDbType = SqlDbType.Structured,
                Direction = direction,
                Value = dataTable
            };

            command.Parameters.Add(parameter);
            return command;
        }
    }
}
