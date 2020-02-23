using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetApplicationPlatformCommandProvider
    {
        public GetApplicationPlatformCommandProvider(GetApplicationPlatformParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        private readonly GetApplicationPlatformParameterProvider _parameterProvider;

        public SqlCommand Get(int id, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetApplicationPlatform)
            .AddInParameter(_parameterProvider.Id, id);
    }
}
