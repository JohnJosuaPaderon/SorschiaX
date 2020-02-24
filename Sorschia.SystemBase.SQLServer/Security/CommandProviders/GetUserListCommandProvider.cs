using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetUserListCommandProvider
    {
        public GetUserListCommandProvider(GetUserListParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        private readonly GetUserListParameterProvider _parameterProvider;

        public SqlCommand Get(GetUserListModel model, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetUserList)
            .AddInParameter(_parameterProvider.FilterText, model.FilterText)
            .AddInParameter(_parameterProvider.FilterByActive, model.FilterByActive)
            .AddInParameter(_parameterProvider.IsActive, model.IsActive)
            .AddInParameter(_parameterProvider.FilterByPasswordChangeRequired, model.FilterByPasswordChangeRequired)
            .AddInParameter(_parameterProvider.IsPasswordChangeRequired, model.IsPasswordChangeRequired)
            .AddIntListParameter(_parameterProvider.SkippedIdList, model.SkippedIdList);
    }
}
