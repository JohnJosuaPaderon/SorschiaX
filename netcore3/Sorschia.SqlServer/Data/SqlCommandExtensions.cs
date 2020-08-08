using Sorschia.Processes;
using Sorschia.SystemCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Sorschia.Data
{
    public static class SqlCommandExtensions
    {
        public static SqlCommand AddInParameter(this SqlCommand instance, string name, object value)
        {
            instance.Parameters.AddIn(name, value);
            return instance;
        }

        public static SqlCommand AddInParameter(this SqlCommand instance, string name, object value, SqlDbType sqlDbType)
        {
            instance.Parameters.AddIn(name, value, sqlDbType);
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
            instance.Parameters.AddInOut(name, value, sqlDbType);
            return instance;
        }

        public static SqlCommand AddInOutParameter(this SqlCommand instance, string name, object value, SqlDbType sqlDbType, int size)
        {
            instance.Parameters.AddInOut(name, value, sqlDbType, size);
            return instance;
        }

        public static SqlCommand AddSessionIdParameter(this SqlCommand instance, ISessionProvider sessionProvider, string parameterName = default) =>
            instance.AddInParameter(string.IsNullOrWhiteSpace(parameterName) ? "@SessionId" : parameterName, sessionProvider.Current?.Id);

        public static SqlCommand AddSkipParameter(this SqlCommand instance, int? skip, string parameterName = default) =>
            instance.AddInParameter(string.IsNullOrWhiteSpace(parameterName) ? "@Skip" : parameterName, skip);

        public static SqlCommand AddTakeParameter(this SqlCommand instance, int? take, string parameterName = default) =>
            instance.AddInParameter(string.IsNullOrWhiteSpace(parameterName) ? "@Take" : parameterName, take);

        public static SqlCommand AddPaginationParameters(this SqlCommand instance, PaginationModel model) => instance
            .AddSkipParameter(model?.Skip)
            .AddTakeParameter(model?.Take);

        public static SqlCommand AddTypeParameter<T>(this SqlCommand instance, string parameterName, IEnumerable<T> values, string dbTypeName, ParameterDirection direction = ParameterDirection.Input)
        {
            var dataTable = new DataTable();

            var type = typeof(T);
            var properties = type.GetProperties();

            if (properties != null && properties.Length > 0)
                foreach (var property in properties)
                    dataTable.Columns.Add(new DataColumn(property.Name, property.PropertyType));

            foreach (var value in values)
                dataTable.Rows.Add(value);

            instance.Parameters.Add(new SqlParameter
            {
                ParameterName = parameterName,
                TypeName = dbTypeName,
                SqlDbType = SqlDbType.Structured,
                Direction = direction,
                Value = dataTable
            });

            return instance;
        }

        public static SqlCommand AddSingleValueTypeParameter<T>(this SqlCommand instance, string parameterName, IEnumerable<T> values, string fieldName, string dbTypeName, ParameterDirection direction = ParameterDirection.Input)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn(fieldName, typeof(T)));

            if (values != null && values.Any())
                foreach (var value in values)
                    dataTable.Rows.Add(value);

            instance.Parameters.Add(new SqlParameter
            {
                ParameterName = parameterName,
                TypeName = dbTypeName,
                SqlDbType = SqlDbType.Structured,
                Direction = direction,
                Value = dataTable
            });

            return instance;
        }

        public static SqlCommand AddIntsParameter(this SqlCommand instance, string parameterName, IEnumerable<int> values, string fieldName = "Value", string dbTypeName = "dbo.Ints", ParameterDirection direction = ParameterDirection.Input) =>
            instance.AddSingleValueTypeParameter(parameterName, values, fieldName, dbTypeName, direction);
    }
}
