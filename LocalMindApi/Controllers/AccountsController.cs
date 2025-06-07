using System.Threading.Tasks;
using LocalMindApi.Models.UserCredentials;
using LocalMindApi.Models.UserTokens;
using LocalMindApi.Services.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace LocalMindApi.Controllers
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("api/login")]
        public async ValueTask<ActionResult<UserToken>> LoginAsync(
            [FromBody] UserCredential userCredential)
        {
            UserToken userToken =
                await this.accountService.LoginAsync(userCredential);

            return Ok(userToken);
        }
    }
}
