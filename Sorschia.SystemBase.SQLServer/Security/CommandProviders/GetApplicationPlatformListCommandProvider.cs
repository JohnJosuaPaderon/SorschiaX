using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetApplicationPlatformListCommandProvider
    {
        public GetApplicationPlatformListCommandProvider(GetApplicationPlatformListParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        private readonly GetApplicationPlatformListParameterProvider _parameterProvider;

        public SqlCommand Get(GetApplicationPlatformListModel model, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetApplicationPlatformList)
            .AddInParameter(_parameterProvider.Skip, model.Skip)
            .AddInParameter(_parameterProvider.Take, model.Take)
            .AddInParameter(_parameterProvider.FilterText, model.FilterText)
            .AddInParameter(_parameterProvider.SkippedIdList, model.SkippedIdList);
    }
}
