using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeleteUserModuleCommandProvider
    {
        public DeleteUserModuleCommandProvider(ICurrentSessionProvider currentSessionProvider, DeleteUserModuleParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly DeleteUserModuleParameterProvider _parameterProvider;

        public SqlCommand Get(long id, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeleteUserModule, transaction)
            .AddInParameter(_parameterProvider.Id, id)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
