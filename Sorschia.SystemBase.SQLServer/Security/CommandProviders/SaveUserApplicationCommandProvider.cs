using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class SaveUserApplicationCommandProvider
    {
        public SaveUserApplicationCommandProvider(ICurrentUserProvider currentUserProvider, SaveUserApplicationParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly SaveUserApplicationParameterProvider _parameterProvider;

        public SqlCommand Get(SystemUserApplication userApplication, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.SaveUserApplication, transaction)
            .AddInOutParameter(_parameterProvider.Id, userApplication.Id, _parameterProvider.Id_Type)
            .AddInParameter(_parameterProvider.UserId, userApplication.UserId)
            .AddInParameter(_parameterProvider.ApplicationId, userApplication.ApplicationId)
            .AddInParameter(_parameterProvider.IsApproved, userApplication.IsApproved)
            .AddInParameter(_parameterProvider.SavedBy, _currentUserProvider.GetUsername());
    }
}
