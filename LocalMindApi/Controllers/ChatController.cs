using System;
using LocalMindApi.Services.Chats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMindApi.Controllers
{
    [Authorize]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService chatService;

        public ChatController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        [HttpGet("api/users/{userId}/chats")]
        public IActionResult GetAllChats(Guid userId)
        {
            var chats = this.chatService.RetrieveAllChatsByUserId(userId);

            return Ok(chats);
        }
    }
}
