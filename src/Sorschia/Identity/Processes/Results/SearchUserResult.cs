using Sorschia.Identity.Entities;
using System.Collections.Generic;

namespace Sorschia.Identity.Processes.Results
{
    public class SearchUserResult
    {
        public IEnumerable<UserObj> Users { get; set; }
        public int TotalCount { get; set; }

        public class UserObj : UserBase
        {
        }
    }
}
