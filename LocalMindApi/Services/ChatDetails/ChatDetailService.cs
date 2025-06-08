using System;
using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.Models.ChatDetails;
using LocalMindApi.Models.Chats;
using LocalMindApi.Repositories.ChatDetails;
using LocalMindApi.Repositories.Chats;

namespace LocalMindApi.Services.ChatDetails
{
    public class ChatDetailService : IChatDetailService
    {
        private readonly IChatDetailRepository chatDetailRepository;
        private readonly IChatRepository chatRepository;

        public ChatDetailService(
            IChatDetailRepository chatDetailRepository,
            IChatRepository chatRepository)
        {
            this.chatDetailRepository = chatDetailRepository;
            this.chatRepository = chatRepository;
        }

        public async ValueTask<ChatDetail> AddChatDetailsAsync(ChatDetail chatDetail, Guid userId)
        {
            Chat maybeChat = this.chatRepository.SelectAllChats()
                .FirstOrDefault(chat => chat.Id == chatDetail.ChatId);

            if (maybeChat is null)
            {
                var newChat = new Chat
                {
                    Id = chatDetail.ChatId,
                    CreatedDate = DateTimeOffset.UtcNow,
                    Name = chatDetail.Source.Substring(0, 5),
                    UserId = userId
                };

                await this.chatRepository.InsertChatAsync(newChat);
            }

            await this.chatDetailRepository.InsertChatDetailAsync(chatDetail);

            return chatDetail;
        }
    }
}
