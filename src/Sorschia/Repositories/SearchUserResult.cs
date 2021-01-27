using Sorschia.Entities;
using System.Collections.Generic;

namespace Sorschia.Repositories
{
    public class SearchUserResult : PaginationResult
    {
        public IList<User> Users { get; set; }
        public int? ActiveCount { get; set; }
        public int? PasswordChangeRequiredCount { get; set; }
        public int? EmailAddressVerifiedCount { get; set; }
        public int? MobileNumberVerifiedCount { get; set; }
    }
}
