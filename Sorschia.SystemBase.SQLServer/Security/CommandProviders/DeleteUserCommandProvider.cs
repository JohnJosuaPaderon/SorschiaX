using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeleteUserCommandProvider
    {
        public DeleteUserCommandProvider(ICurrentUserProvider currentUserProvider, DeleteUserParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly DeleteUserParameterProvider _parameterProvider;

        public SqlCommand Get(DeleteUserModel model, SqlConnection connection, SqlTransaction transaction = default) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeleteUser, transaction)
            .AddInParameter(_parameterProvider.Id, model.Id)
            .AddInParameter(_parameterProvider.DeletedBy, _currentUserProvider.GetUsername());
    }
}
