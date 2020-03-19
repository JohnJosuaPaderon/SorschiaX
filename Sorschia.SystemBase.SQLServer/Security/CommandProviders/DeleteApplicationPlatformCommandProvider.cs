using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeleteApplicationPlatformCommandProvider
    {
        public DeleteApplicationPlatformCommandProvider(ICurrentSessionProvider currentSessionProvider, DeleteApplicationPlatformParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly DeleteApplicationPlatformParameterProvider _parameterProvider;

        public SqlCommand Get(DeleteApplicationPlatformModel model, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeleteApplicationPlatform, transaction)
            .AddInParameter(_parameterProvider.Id, model.Id)
            .AddInParameter(_parameterProvider.IsCascaded, model.IsCascaded)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
