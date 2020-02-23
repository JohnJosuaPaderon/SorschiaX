using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeleteApplicationCommandProvider
    {
        public DeleteApplicationCommandProvider(ICurrentUserProvider currentUserProvider, DeleteApplicationParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly DeleteApplicationParameterProvider _parameterProvider;

        public SqlCommand Get(DeleteApplicationModel model, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeleteApplication, transaction)
            .AddInParameter(_parameterProvider.Id, model.Id)
            .AddInParameter(_parameterProvider.IsCascaded, model.IsCascaded)
            .AddInParameter(_parameterProvider.DeletedBy, _currentUserProvider.GetUsername());
    }
}
