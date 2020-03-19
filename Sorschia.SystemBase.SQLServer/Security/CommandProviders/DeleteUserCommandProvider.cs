using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeleteUserCommandProvider
    {
        public DeleteUserCommandProvider(ICurrentSessionProvider currentSessionProvider, DeleteUserParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly DeleteUserParameterProvider _parameterProvider;

        public SqlCommand Get(DeleteUserModel model, SqlConnection connection, SqlTransaction transaction = default) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeleteUser, transaction)
            .AddInParameter(_parameterProvider.Id, model.Id)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
