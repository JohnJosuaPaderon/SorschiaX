using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeleteApplicationPlatformCommandProvider
    {
        public DeleteApplicationPlatformCommandProvider(ICurrentUserProvider currentUserProvider, DeleteApplicationPlatformParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly DeleteApplicationPlatformParameterProvider _parameterProvider;

        public SqlCommand Get(DeleteApplicationPlatformModel model, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeleteApplicationPlatform, transaction)
            .AddInParameter(_parameterProvider.Id, model.Id)
            .AddInParameter(_parameterProvider.IsCascaded, model.IsCascaded)
            .AddInParameter(_parameterProvider.DeletedBy, _currentUserProvider.GetUsername());
    }
}
