using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.Models.Users;

namespace LocalMindApi.Services.Users
{
    public interface IUserService
    {
        ValueTask<User> AddUserAsync(User user);
        IQueryable<User> RetrieveAllUsers();
    }
}
