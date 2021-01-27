using Sorschia.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddAsync(AddUserModel model, CancellationToken cancellationToken = default);
        Task ChangePasswordAsync(ChangeUserPasswordModel model, CancellationToken cancellationToken = default);
        Task<User> EditAsync(EditUserModel model, CancellationToken cancellationToken = default);
        Task<User> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<User> LoginAsync(LoginUserModel model, CancellationToken cancellationToken = default);
        Task<SearchUserResult> SearchUserAsync(SearchUserModel model, CancellationToken cancellationToken = default);
    }
}
