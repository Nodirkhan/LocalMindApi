using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.DTOs;

namespace LocalMindApi.Services.Users
{
    public interface IUserService
    {
        ValueTask<UserDto> AddUserAsync(UserDto userDto);
        IQueryable<UserDto> RetrieveAllUsers();
    }
}
