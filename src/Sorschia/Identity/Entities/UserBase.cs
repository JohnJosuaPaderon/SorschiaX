namespace Sorschia.Identity.Entities
{
    public abstract class UserBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public UserStatus Status { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public long? PersonId { get; set; }
    }
}
