using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetApplicationListCommandProvider
    {
        public GetApplicationListCommandProvider(GetApplicationListParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }
        
        private readonly GetApplicationListParameterProvider _parameterProvider;

        public SqlCommand Get(GetApplicationListModel model, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetApplicationList)
            .AddInParameter(_parameterProvider.Skip, model.Skip)
            .AddInParameter(_parameterProvider.Take, model.Take)
            .AddInParameter(_parameterProvider.FilterText, model.FilterText)
            .AddInParameter(_parameterProvider.FilterByPlatform, model.FilterByPlatform)
            .AddIntListParameter(_parameterProvider.PlatformIdList, model.PlatformIdList)
            .AddIntListParameter(_parameterProvider.SkippedIdList, model.SkippedIdList);
    }
}
