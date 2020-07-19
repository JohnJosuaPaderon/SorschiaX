using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sorschia.Data
{
    internal sealed class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string this[string key]
        { 
            get => _configuration.GetConnectionString(key); 
            set => throw new NotImplementedException("Modify directly the appsettings.json");
        }
    }
}
