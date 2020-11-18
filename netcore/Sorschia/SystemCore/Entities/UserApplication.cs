namespace Sorschia.SystemCore.Entities
{
    /// <summary>
    /// Relational representation of User-Application
    /// </summary>
    public class UserApplication
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int ApplicationId { get; set; }

        public User User { get; set; }
        public Application Application { get; set; }
    }
}
