using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeleteModuleCommandProvider
    {
        public DeleteModuleCommandProvider(ICurrentSessionProvider currentSessionProvider, DeleteModuleParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly DeleteModuleParameterProvider _parameterProvider;

        public SqlCommand Get(DeleteModuleModel model, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeleteModule, transaction)
            .AddInParameter(_parameterProvider.Id, model.Id)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
