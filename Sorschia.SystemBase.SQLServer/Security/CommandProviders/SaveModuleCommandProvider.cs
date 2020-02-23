using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class SaveModuleCommandProvider
    {
        public SaveModuleCommandProvider(ICurrentUserProvider currentUserProvider, SaveModuleParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly SaveModuleParameterProvider _parameterProvider;

        public SqlCommand Get(SystemModule module, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.SaveModule, transaction)
            .AddInOutParameter(_parameterProvider.Id, module.Id, _parameterProvider.Id_Type)
            .AddInParameter(_parameterProvider.Name, module.Name)
            .AddInParameter(_parameterProvider.OrdinalNumber, module.OrdinalNumber)
            .AddInParameter(_parameterProvider.ApplicationId, module.ApplicationId)
            .AddInParameter(_parameterProvider.SavedBy, _currentUserProvider.GetUsername());
    }
}
