using MediatR;
using Sorschia.Entities;
using Sorschia.Processes.Results;
using System.Collections.Generic;

namespace Sorschia.Processes
{
    public class SaveUser : UserBase, IRequest<SaveUserResult>
    {
        public IEnumerable<short>? ApplicationIds { get; set; }
        public IEnumerable<int>? RoleIds { get; set; }
        public IEnumerable<int>? PermissionIds { get; set; }
    }
}
