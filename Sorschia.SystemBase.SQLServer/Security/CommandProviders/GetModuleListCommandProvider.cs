using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetModuleListCommandProvider
    {
        public GetModuleListCommandProvider(GetModuleListParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        private readonly GetModuleListParameterProvider _parameterProvider;

        public SqlCommand Get(GetModuleListModel model, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetModuleList)
            .AddInParameter(_parameterProvider.Skip, model.Skip)
            .AddInParameter(_parameterProvider.Take, model.Take)
            .AddInParameter(_parameterProvider.FilterText, model.FilterText)
            .AddInParameter(_parameterProvider.FilterByApplication, model.FilterByApplication)
            .AddIntListParameter(_parameterProvider.ApplicationIdList, model.ApplicationIdList)
            .AddIntListParameter(_parameterProvider.SkippedIdList, model.SkippedIdList);
    }
}
