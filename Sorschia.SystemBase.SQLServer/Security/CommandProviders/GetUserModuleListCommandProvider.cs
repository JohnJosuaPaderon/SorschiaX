using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetUserModuleListCommandProvider
    {
        public GetUserModuleListCommandProvider(GetUserModuleListParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        private readonly GetUserModuleListParameterProvider _parameterProvider;

        public SqlCommand Get(GetUserModuleListModel model, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetUserModuleList)
            .AddInParameter(_parameterProvider.Skip, model.Skip)
            .AddInParameter(_parameterProvider.Take, model.Take)
            .AddInParameter(_parameterProvider.FilterByApproved, model.FilterByApproved)
            .AddInParameter(_parameterProvider.IsApproved, model.IsApproved)
            .AddInParameter(_parameterProvider.FilterByUser, model.FilterByUser)
            .AddIntListParameter(_parameterProvider.UserIdList, model.UserIdList)
            .AddInParameter(_parameterProvider.FilterByModule, model.FilterByModule)
            .AddIntListParameter(_parameterProvider.ModuleIdList, model.ModuleIdList);
    }
}
