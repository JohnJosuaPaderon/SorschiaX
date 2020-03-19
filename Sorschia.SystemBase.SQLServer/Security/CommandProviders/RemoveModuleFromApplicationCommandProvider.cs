using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class RemoveModuleFromApplicationCommandProvider
    {
        public RemoveModuleFromApplicationCommandProvider(ICurrentSessionProvider currentSessionProvider, RemoveModuleFromApplicationParameterProvider parameterProvider)
        {
            _currentSessionProvider = currentSessionProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentSessionProvider _currentSessionProvider;
        private readonly RemoveModuleFromApplicationParameterProvider _parameterProvider;

        public SqlCommand Get(int moduleId, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.RemoveModuleFromApplication, transaction)
            .AddInParameter(_parameterProvider.ModuleId, moduleId)
            .AddSessionIdParameter(_currentSessionProvider);
    }
}
