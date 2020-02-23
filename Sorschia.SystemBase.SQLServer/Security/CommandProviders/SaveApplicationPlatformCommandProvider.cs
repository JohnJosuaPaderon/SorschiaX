using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class SaveApplicationPlatformCommandProvider
    {
        public SaveApplicationPlatformCommandProvider(ICurrentUserProvider currentUserProvider, SaveApplicationPlatformParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly SaveApplicationPlatformParameterProvider _parameterProvider;

        public SqlCommand Get(SystemApplicationPlatform applicationPlatform, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.SaveApplicationPlatform, transaction)
            .AddInOutParameter(_parameterProvider.Id, applicationPlatform.Id, _parameterProvider.Id_Type)
            .AddInParameter(_parameterProvider.Name, applicationPlatform.Name)
            .AddInParameter(_parameterProvider.SavedBy, _currentUserProvider.GetUsername());
    }
}
