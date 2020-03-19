using Sorschia.SystemBase.Security;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Data
{
    internal static class SqlCommandExtensions
    {
        public static SqlCommand AddSessionIdParameter(this SqlCommand instance, ICurrentSessionProvider currentSessionProvider, string parameterName = default)
        {
            return instance.AddInParameter(string.IsNullOrWhiteSpace(parameterName) ? "@SessionId" : parameterName, currentSessionProvider.GetId());
        }
    }
}
