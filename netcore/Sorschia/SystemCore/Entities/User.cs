using Sorschia.Utilities;

namespace Sorschia.SystemCore.Entities
{
    /// <summary>
    /// Representation of User in the system
    /// </summary>
    public class User : NameBase
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string NewCipherPassword { get; set; }
        public string OldCipherPassword { get; set; }
        public bool IsActive { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public bool IsEmailVerified { get; set; }
    }
}
