using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.Models.Users;
using LocalMindApi.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMindApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<User>> PostUserAsync([FromBody] User user)
        {
            User newUser =
                await this.userService.AddUserAsync(user);

            return StatusCode(201, user);
        }

        [HttpGet]
        public ActionResult<IQueryable<User>> GetAllUsers()
        {
            IQueryable<User> users =
                this.userService.RetrieveAllUsers();

            return Ok(users);
        }
    }
}
