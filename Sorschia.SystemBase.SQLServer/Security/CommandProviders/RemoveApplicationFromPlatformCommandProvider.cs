using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class RemoveApplicationFromPlatformCommandProvider
    {
        public RemoveApplicationFromPlatformCommandProvider(ICurrentUserProvider currentUserProvider, RemoveApplicationFromPlatformParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly RemoveApplicationFromPlatformParameterProvider _parameterProvider;

        public SqlCommand Get(int applicationId, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.RemoveApplicationFromPlatform, transaction)
            .AddInParameter(_parameterProvider.ApplicationId, applicationId)
            .AddInParameter(_parameterProvider.UpdatedBy, _currentUserProvider.GetUsername());
    }
}
