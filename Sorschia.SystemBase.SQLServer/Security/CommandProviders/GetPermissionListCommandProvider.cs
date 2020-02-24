using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetPermissionListCommandProvider
    {
        public GetPermissionListCommandProvider(GetPermissionListParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        private readonly GetPermissionListParameterProvider _parameterProvider;

        public SqlCommand Get(GetPermissionListModel model, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetPermissionList)
            .AddInParameter(_parameterProvider.Skip, model.Skip)
            .AddInParameter(_parameterProvider.Take, model.Take)
            .AddInParameter(_parameterProvider.FilterText, model.FilterText)
            .AddIntListParameter(_parameterProvider.SkippedIdList, model.SkippedIdList);
    }
}
