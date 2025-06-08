using System;
using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.Models.Chats;

namespace LocalMindApi.Services.Chats
{
    public interface IChatService
    {
        IQueryable<Chat> RetrieveAllChatsByUserId(Guid userId);
        ValueTask<Chat> RetrieveChatWithChatDetailsByChatIdAsync(Guid chatId);
    }
}
