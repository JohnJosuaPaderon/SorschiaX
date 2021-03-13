namespace Sorschia.Data
{
    public sealed partial class DataOptions
    {
        public Application_OptionsObj Application { get; init; } = new Application_OptionsObj("Application", "dbo");
        public Permission_OptionsObj Permission { get; init; } = new Permission_OptionsObj("Permission", "dbo");
        public PermissionAspNetRoute_OptionsObj PermissionAspNetRoute { get; init; } = new PermissionAspNetRoute_OptionsObj("PermissionAspNetRoute", "dbo");
        public Role_OptionsObj Role { get; init; } = new Role_OptionsObj("Role", "dbo");
        public User_OptionsObj User { get; init; } = new User_OptionsObj("User", "dbo");
    }
}
