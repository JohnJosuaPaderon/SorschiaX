using System.Data;
using System.Data.SqlClient;

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
    }
}
