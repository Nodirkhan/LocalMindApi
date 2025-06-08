using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.DTOs;

namespace LocalMindApi.Services.Users
{
    public interface IUserService
    {
        ValueTask<UserDTO> AddUserAsync(UserDTO userDTO);
        IQueryable<UserDTO> RetrieveAllUsers();
    }
}
