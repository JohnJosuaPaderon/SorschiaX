using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class RemoveApplicationFromPlatformCommandProvider
    {
        public RemoveApplicationFromPlatformCommandProvider(ICurrentSessionProvider currentSessionProvider, RemoveApplicationFromPlatformParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly RemoveApplicationFromPlatformParameterProvider _parameterProvider;

        public SqlCommand Get(int applicationId, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.RemoveApplicationFromPlatform, transaction)
            .AddInParameter(_parameterProvider.ApplicationId, applicationId)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
