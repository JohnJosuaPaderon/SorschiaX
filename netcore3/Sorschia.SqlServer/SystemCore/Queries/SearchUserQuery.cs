﻿using Sorschia.Data;
using Sorschia.Queries;
using Sorschia.SystemCore.Converters;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SearchUserQuery : PaginationQueryBase
    {
        private const string PROCEDURE = "[SystemCore].[SearchUser]";
        private const string PARAM_FILTERTEXT = "@FilterText";
        private const string PARAM_ISACTIVE = "@IsActive";
        private const string PARAM_ISPASSWORDCHANGEREQUIRED = "@IsPasswordChangeRequired";
        private const string PARAM_SKIPPEDIDS = "@SkippedIds";

        private readonly UserConverter _converter;

        public SearchUserQuery(UserConverter converter)
        {
            _converter = converter;
        }

        public async Task ExecuteAsync(SearchUserModel model, SearchUserResult result, SqlConnection connection, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
                while (await reader.ReadAsync(cancellationToken))
                    result.Users.Add(_converter.Convert(reader));

            await ReadTotalCountAsync(reader, result, cancellationToken);
        }

        private SqlCommand CreateCommand(SearchUserModel model, SqlConnection connection) => connection
            .CreateProcedureCommand(PROCEDURE)
            .AddPaginationParameters(model)
            .AddInParameter(PARAM_FILTERTEXT, model.FilterText)
            .AddInParameter(PARAM_ISACTIVE, model.IsActive)
            .AddInParameter(PARAM_ISPASSWORDCHANGEREQUIRED, model.IsPasswordChangeRequired)
            .AddIntListParameter(PARAM_SKIPPEDIDS, model.SkippedIds);
    }

}