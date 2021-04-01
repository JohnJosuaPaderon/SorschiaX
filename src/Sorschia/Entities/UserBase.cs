namespace Sorschia.Entities
{
    public abstract class UserBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = default!;
        public string? NameSuffix { get; set; }
        public string FullName { get; set; } = default!;
        public string Username { get; set; } = default!;
        public bool IsActive { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
    }
}
