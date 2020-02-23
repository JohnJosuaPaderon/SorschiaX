﻿using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class SaveApplicationCommandProvider
    {
        public SaveApplicationCommandProvider(SaveApplicationParameterProvider parameterProvider, ICurrentUserProvider currentUserProvider)
        {
            _parameterProvider = parameterProvider;
            _currentUserProvider = currentUserProvider;
        }

        private readonly SaveApplicationParameterProvider _parameterProvider;
        private readonly ICurrentUserProvider _currentUserProvider;

        public SqlCommand Get(SystemApplication application, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.SaveApplication, transaction)
            .AddInOutParameter(_parameterProvider.Id, application.Id, _parameterProvider.Id_Type)
            .AddInParameter(_parameterProvider.Name, application.Name)
            .AddInParameter(_parameterProvider.PlatformId, application.PlatformId)
            .AddInParameter(_parameterProvider.SavedBy, _currentUserProvider.GetUsername());
    }
}
