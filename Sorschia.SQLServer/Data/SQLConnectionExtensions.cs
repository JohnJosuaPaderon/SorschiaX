using System.Data;
using System.Data.SqlClient;

namespace Sorschia.Data
{
    public static class SQLConnectionExtensions
    {
        public static SqlCommand CreateCommand(this SqlConnection instance, string commandText, SqlTransaction transaction = default)
        {
            var command = instance.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = commandText;

            return command;
        }

        public static SqlCommand CreateProcedureCommand(this SqlConnection instance, string procedure, SqlTransaction transaction = default)
        {
            var command = instance.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = procedure;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public static SqlCommand CreateProcedureCommand(this SqlConnection instance, string schema, string procedure, SqlTransaction transaction = default)
        {
            return instance.CreateProcedureCommand($"{schema}.{procedure}", transaction);
        }
    }
}
