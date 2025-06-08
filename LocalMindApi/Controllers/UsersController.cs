using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.DTOs;
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
        public async ValueTask<ActionResult<User>> PostUserAsync([FromBody] UserDTO userDTO)
        {
            UserDTO newUser =
                await this.userService.AddUserAsync(userDTO);

            return StatusCode(201, userDTO);
        }

        [HttpGet]
        public ActionResult<IQueryable<UserDTO>> GetAllUsers()
        {
            IQueryable<UserDTO> users =
                this.userService.RetrieveAllUsers();

            return Ok(users);
        }
    }
}
