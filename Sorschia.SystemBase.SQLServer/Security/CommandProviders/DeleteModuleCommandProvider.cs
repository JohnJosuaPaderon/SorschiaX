using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeleteModuleCommandProvider
    {
        public DeleteModuleCommandProvider(ICurrentUserProvider currentUserProvider, DeleteModuleParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly DeleteModuleParameterProvider _parameterProvider;

        public SqlCommand Get(DeleteModuleModel model, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeleteModule, transaction)
            .AddInParameter(_parameterProvider.Id, model.Id)
            .AddInParameter(_parameterProvider.DeletedBy, _currentUserProvider.GetUsername());
    }
}
