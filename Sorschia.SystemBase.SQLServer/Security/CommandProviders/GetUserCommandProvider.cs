using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetUserCommandProvider
    {
        public GetUserCommandProvider(GetUserParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        private readonly GetUserParameterProvider _parameterProvider;

        public SqlCommand Get(int id, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetUser)
            .AddInParameter(_parameterProvider.Id, id);
    }
}
