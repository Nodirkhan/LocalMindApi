using System;
using System.Linq;
using LocalMindApi.Models.Chats;
using LocalMindApi.Repositories.Chats;

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
                .OrderByDescending(chat => chat.CreatedDate);
        }
    }
}
