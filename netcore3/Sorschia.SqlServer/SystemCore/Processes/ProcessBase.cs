using Sorschia.Data;
using Sorschia.Processes;
using System.Data.SqlClient;

namespace Sorschia.SystemCore.Processes
{
    internal abstract class ProcessBase : SqlProcessBase
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        
        public ProcessBase(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        protected override SqlConnection InitializeConnection() => new SqlConnection(_connectionStringProvider["sorschia_systemCore"]);
    }
}
