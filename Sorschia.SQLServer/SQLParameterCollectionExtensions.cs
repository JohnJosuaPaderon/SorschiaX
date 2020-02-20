using System.Data;
using System.Data.SqlClient;

namespace Sorschia
{
    public static class SQLParameterCollectionExtensions
    {
        public static SqlParameterCollection AddIn(this SqlParameterCollection instance, string name, object value)
        {
            instance.Add(new SqlParameter(name, value));

            return instance;
        }

        public static SqlParameterCollection AddIn(this SqlParameterCollection instance, string name, object value, SqlDbType sqlDbType)
        {
            instance.Add(new SqlParameter(name, value)
            {
                SqlDbType = sqlDbType
            });

            return instance;
        }

        public static SqlParameterCollection AddOut(this SqlParameterCollection instance, string name, SqlDbType sqlDbType)
        {
            instance.Add(new SqlParameter
            {
                ParameterName = name,
                SqlDbType = sqlDbType,
                Direction = ParameterDirection.Output
            });

            return instance;
        }

        public static SqlParameterCollection AddOut(this SqlParameterCollection instance, string name, SqlDbType sqlDbType, int size)
        {
            instance.Add(new SqlParameter
            {
                ParameterName = name,
                SqlDbType = sqlDbType,
                Direction = ParameterDirection.Output,
                Size = size
            });

            return instance;
        }

        public static SqlParameterCollection AddInOut(this SqlParameterCollection instance, string name, object value, SqlDbType sqlDbType)
        {
            instance.Add(new SqlParameter
            {
                ParameterName = name,
                SqlDbType = sqlDbType,
                Value = value,
                Direction = ParameterDirection.InputOutput
            });

            return instance;
        }

        public static SqlParameterCollection AddInOut(this SqlParameterCollection instance, string name, object value, SqlDbType sqlDbType, int size)
        {
            instance.Add(new SqlParameter
            {
                ParameterName = name,
                SqlDbType = sqlDbType,
                Value = value,
                Direction = ParameterDirection.InputOutput,
                Size = size
            });

            return instance;
        }
    }
}
