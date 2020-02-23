using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class RemoveModuleFromApplicationCommandProvider
    {
        public RemoveModuleFromApplicationCommandProvider(ICurrentUserProvider currentUserProvider, RemoveModuleFromApplicationParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly RemoveModuleFromApplicationParameterProvider _parameterProvider;

        public SqlCommand Get(int moduleId, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.RemoveModuleFromApplication, transaction)
            .AddInParameter(_parameterProvider.ModuleId, moduleId)
            .AddInParameter(_parameterProvider.UpdatedBy, _currentUserProvider.GetUsername());
    }
}
