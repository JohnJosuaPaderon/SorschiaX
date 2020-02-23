using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetApplicationCommandProvider
    {
        public GetApplicationCommandProvider(GetApplicationParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        private readonly GetApplicationParameterProvider _parameterProvider;

        public SqlCommand Get(int id, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetApplication)
            .AddInParameter(_parameterProvider.Id, id);
    }
}
