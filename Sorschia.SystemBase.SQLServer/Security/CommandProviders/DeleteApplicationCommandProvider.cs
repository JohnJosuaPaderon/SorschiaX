using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeleteApplicationCommandProvider
    {
        public DeleteApplicationCommandProvider(ICurrentSessionProvider currentSessionProvider, DeleteApplicationParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly DeleteApplicationParameterProvider _parameterProvider;

        public SqlCommand Get(DeleteApplicationModel model, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeleteApplication, transaction)
            .AddInParameter(_parameterProvider.Id, model.Id)
            .AddInParameter(_parameterProvider.IsCascaded, model.IsCascaded)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
