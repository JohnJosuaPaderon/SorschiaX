namespace Sorschia.Entities
{
    public class UserApplication : EntityBase, IIdInt64
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int ApplicationId { get; set; }

        public User User { get; set; }
        public Application Application { get; set; }
    }
}
