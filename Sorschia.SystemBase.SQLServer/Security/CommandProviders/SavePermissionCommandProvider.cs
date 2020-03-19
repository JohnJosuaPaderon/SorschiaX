using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class SavePermissionCommandProvider
    {
        public SavePermissionCommandProvider(ICurrentSessionProvider currentSessionProvider, SavePermissionParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly SavePermissionParameterProvider _parameterProvider;

        public SqlCommand Get(SystemPermission permission, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.SavePermission, transaction)
            .AddInOutParameter(_parameterProvider.Id, permission.Id, _parameterProvider.Id_Type)
            .AddInParameter(_parameterProvider.Name, permission.Name)
            .AddInParameter(_parameterProvider.Code, permission.Code)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
