using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeletePermissionCommandProvider
    {
        public DeletePermissionCommandProvider(ICurrentUserProvider currentUserProvider, DeletePermissionParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly DeletePermissionParameterProvider _parameterProvider;

        public SqlCommand Get(DeletePermissionModel model, SqlConnection connection, SqlTransaction transaction = default) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeletePermission, transaction)
            .AddInParameter(_parameterProvider.Id, model.Id)
            .AddInParameter(_parameterProvider.DeletedBy, _currentUserProvider.GetUsername());
    }
}
