using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class SaveUserModuleCommandProvider
    {
        public SaveUserModuleCommandProvider(ICurrentSessionProvider currentSessionProvider, SaveUserModuleParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly SaveUserModuleParameterProvider _parameterProvider;

        public SqlCommand Get(SystemUserModule userModule, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.SaveUserModule, transaction)
            .AddInOutParameter(_parameterProvider.Id, userModule.Id, _parameterProvider.Id_Type)
            .AddInParameter(_parameterProvider.UserId, userModule.UserId)
            .AddInParameter(_parameterProvider.ModuleId, userModule.ModuleId)
            .AddInParameter(_parameterProvider.IsApproved, userModule.IsApproved)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
