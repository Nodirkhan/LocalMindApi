using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.Models.Users;

namespace LocalMindApi.Repositories.Users
{
    public interface IUserRepository
    {
        ValueTask<User> InsertUserAsync(User user);
        IQueryable<User> SelectAllUsers();
    }
}
