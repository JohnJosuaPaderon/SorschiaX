using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class SavePermissionCommandProvider
    {
        public SavePermissionCommandProvider(ICurrentUserProvider currentUserProvider, SavePermissionParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly SavePermissionParameterProvider _parameterProvider;

        public SqlCommand Get(SystemPermission permission, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.SavePermission, transaction)
            .AddInOutParameter(_parameterProvider.Id, permission.Id, _parameterProvider.Id_Type)
            .AddInParameter(_parameterProvider.Name, permission.Name)
            .AddInParameter(_parameterProvider.Code, permission.Code)
            .AddInParameter(_parameterProvider.SavedBy, _currentUserProvider.GetUsername());
    }
}
