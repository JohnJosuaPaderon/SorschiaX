namespace Sorschia.Repositories
{
    public class ChangeUserPasswordModel
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
