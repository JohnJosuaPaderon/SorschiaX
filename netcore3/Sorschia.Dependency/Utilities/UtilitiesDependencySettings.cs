namespace Sorschia.Utilities
{
    public sealed class UtilitiesDependencySettings
    {
        public bool UseDependencyResolver { get; set; } = true;
        public bool UseDefaultFullNameBuilder { get; set; } = true;

        internal UtilitiesDependencySettings() { }
    }
}
