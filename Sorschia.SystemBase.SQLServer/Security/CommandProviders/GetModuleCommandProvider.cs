using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetModuleCommandProvider
    {
        public GetModuleCommandProvider(GetModuleParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        private readonly GetModuleParameterProvider _parameterProvider;

        public SqlCommand Get(int id, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetModule)
            .AddInParameter(_parameterProvider.Id, id);
    }
}
