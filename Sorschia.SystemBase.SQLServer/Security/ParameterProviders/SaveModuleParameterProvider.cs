using System.Data;

namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class SaveModuleParameterProvider
    {
        public string Id { get; } = "@Id";
        public string Name { get; } = "@Name";
        public string OrdinalNumber { get; } = "@OrdinalNumber";
        public string ApplicationId { get; } = "@ApplicationId";
        public SqlDbType Id_Type { get; } = SqlDbType.Int;
    }
}
