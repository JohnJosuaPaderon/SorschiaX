namespace Sorschia.Entities
{
    public class UserApplication
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public short ApplicationId { get; set; }

        public User? User { get; set; }
        public Application? Application { get; set; }
    }
}
