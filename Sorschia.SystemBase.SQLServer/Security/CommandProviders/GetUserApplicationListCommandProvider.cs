﻿using Sorschia.SystemBase.Security.ParameterProviders;
using Sorschia.SystemBase.Security.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class GetUserApplicationListCommandProvider
    {
        public GetUserApplicationListCommandProvider(GetUserApplicationListParameterProvider parameterProvider)
        {
            _parameterProvider = parameterProvider;
        }

        private readonly GetUserApplicationListParameterProvider _parameterProvider;

        public SqlCommand Get(GetUserApplicationListModel model, SqlConnection connection) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.GetUserApplicationList)
            .AddInParameter(_parameterProvider.FilterByApproved, model.FilterByApproved)
            .AddInParameter(_parameterProvider.IsApproved, model.IsApproved)
            .AddInParameter(_parameterProvider.FilterByUser, model.FilterByUser)
            .AddInParameter(_parameterProvider.UserIdList, model.UserIdList)
            .AddInParameter(_parameterProvider.FilterByApplication, model.FilterByApplication)
            .AddInParameter(_parameterProvider.ApplicationIdList, model.ApplicationIdList);
    }
}