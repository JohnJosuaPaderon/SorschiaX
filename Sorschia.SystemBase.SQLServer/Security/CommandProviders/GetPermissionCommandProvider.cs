using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetPermissionCommandProvider
    {
        public GetPermissionCommandProvider(GetPermissionParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        private readonly GetPermissionParameterProvider _parameterProvider;

        public SqlCommand Get(int id, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetPermission)
            .AddInParameter(_parameterProvider.Id, id);
    }
}
