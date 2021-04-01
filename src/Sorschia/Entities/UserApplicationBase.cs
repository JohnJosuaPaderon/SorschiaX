namespace Sorschia.Entities
{
    public abstract class UserApplicationBase
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public short ApplicationId { get; set; }
    }
}
