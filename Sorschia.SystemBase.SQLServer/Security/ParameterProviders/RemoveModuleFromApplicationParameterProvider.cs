namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class RemoveModuleFromApplicationParameterProvider
    {
        public string ModuleId { get; } = "@ModuleId";
        public string UpdatedBy { get; } = "@UpdatedBy";
    }
 }
