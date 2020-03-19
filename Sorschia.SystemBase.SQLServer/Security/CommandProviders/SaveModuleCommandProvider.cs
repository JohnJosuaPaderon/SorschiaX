using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class SaveModuleCommandProvider
    {
        public SaveModuleCommandProvider(ICurrentSessionProvider currentSessionProvider, SaveModuleParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly SaveModuleParameterProvider _parameterProvider;

        public SqlCommand Get(SystemModule module, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.SaveModule, transaction)
            .AddInOutParameter(_parameterProvider.Id, module.Id, _parameterProvider.Id_Type)
            .AddInParameter(_parameterProvider.Name, module.Name)
            .AddInParameter(_parameterProvider.OrdinalNumber, module.OrdinalNumber)
            .AddInParameter(_parameterProvider.ApplicationId, module.ApplicationId)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
