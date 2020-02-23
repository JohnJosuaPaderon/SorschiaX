﻿using Sorschia.Data;
using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.CommandProviders;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security.Processes
{
    internal sealed class DeleteApplication : SQLProcessBase, IDeleteApplication
    {
        public DeleteApplication(
            IConnectionStringProvider connectionStringProvider, 
            DeleteApplicationCommandProvider deleteApplicationCommandProvider) : base(connectionStringProvider.GetDefault())
        {
            _deleteApplicationCommandProvider = deleteApplicationCommandProvider;
        }

        private readonly DeleteApplicationCommandProvider _deleteApplicationCommandProvider;

        public DeleteApplicationModel Model { get; set; }

        private async Task<bool> ExecuteDeleteApplicationAsync(DeleteApplicationModel model, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _deleteApplicationCommandProvider.Get(model, connection, transaction);
            return await command.ExecuteNonQueryAsync(cancellationToken) == 1;
        }

        public async Task<bool> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                var result = await ExecuteDeleteApplicationAsync(model, connection, transaction, cancellationToken);
                transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }
    }
}