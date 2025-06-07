using System.Threading.Tasks;
using LocalMindApi.Models.UserCredentials;
using LocalMindApi.Models.UserTokens;

namespace LocalMindApi.Services.Accounts
{
    public interface IAccountService
    {
        ValueTask<UserToken> LoginAsync(UserCredential userCredential);
    }
}
