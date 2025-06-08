using System;
using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.Models.Chats;
using LocalMindApi.Repositories.Chats;
using Microsoft.EntityFrameworkCore;

namespace LocalMindApi.Services.Chats
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            this.chatRepository = chatRepository;
        }

        public IQueryable<Chat> RetrieveAllChatsByUserId(Guid userId)
        {
            return this.chatRepository.SelectAllChats()
                .Where(chat => chat.UserId == userId)
                .OrderBy(chat => chat.CreatedDate);
        }

        public async ValueTask<Chat> RetrieveChatWithChatDetailsByChatIdAsync(Guid chatId)
        {
            return await this.chatRepository.SelectAllChats()
                .Include(chat => chat.ChatDetails)
                .Where(chat => chat.Id == chatId)
                .FirstOrDefaultAsync();
        }
    }
}
