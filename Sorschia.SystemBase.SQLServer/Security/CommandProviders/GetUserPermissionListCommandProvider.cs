using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetUserPermissionListCommandProvider
    {
        public GetUserPermissionListCommandProvider(GetUserPermissionListParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        private readonly GetUserPermissionListParameterProvider _parameterProvider;

        public SqlCommand Get(GetUserPermissionListModel model, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetUserPermissionList)
            .AddInParameter(_parameterProvider.FilterByApproved, model.FilterByApproved)
            .AddInParameter(_parameterProvider.IsApproved, model.IsApproved)
            .AddInParameter(_parameterProvider.FilterByUser, model.FilterByUser)
            .AddIntListParameter(_parameterProvider.UserIdList, model.UserIdList)
            .AddInParameter(_parameterProvider.FilterByPermission, model.FilterByPermission)
            .AddIntListParameter(_parameterProvider.PermissionIdList, model.PermissionIdList);
    }
}
