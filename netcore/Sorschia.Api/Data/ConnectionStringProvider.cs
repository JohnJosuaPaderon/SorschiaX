using Microsoft.Extensions.Configuration;
using System;

namespace Sorschia.Data
{
    internal sealed class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string this[string key, params string[] fallbackKeys]
        {
            get
            {
                var connectionString = _configuration.GetConnectionString(key);

                if (connectionString is null && fallbackKeys != null && fallbackKeys.Length > 0)
                    foreach (var fallbackKey in fallbackKeys)
                    {
                        connectionString = _configuration.GetConnectionString(fallbackKey);

                        if (connectionString != null)
                            return connectionString;
                    }

                return connectionString;
            }
            set => throw new NotImplementedException("Modify directly the appsettings.json");
        }
    }
}
