using System;
using System.Linq;
using LocalMindApi.Models.Chats;

namespace LocalMindApi.Services.Chats
{
    public interface IChatService
    {
        IQueryable<Chat> RetrieveAllChatsByUserId(Guid userId);
    }
}
