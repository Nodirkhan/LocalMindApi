using System;
using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.Models.ChatDetails;
using LocalMindApi.Models.Chats;
using LocalMindApi.Models.LocalAIs;
using LocalMindApi.Repositories.ChatDetails;
using LocalMindApi.Repositories.Chats;
using LocalMindApi.Repositories.LocalAIs;

namespace LocalMindApi.Services.ChatDetails
{
    public class ChatDetailService : IChatDetailService
    {
        private readonly IChatDetailRepository chatDetailRepository;
        private readonly IChatRepository chatRepository;
        private readonly ILocalAIApiRepository localAIApiRepository;

        public ChatDetailService(
            IChatDetailRepository chatDetailRepository,
            IChatRepository chatRepository,
            ILocalAIApiRepository localAIApiRepository)
        {
            this.chatDetailRepository = chatDetailRepository;
            this.chatRepository = chatRepository;
            this.localAIApiRepository = localAIApiRepository;
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

            var localAIRequest = new LocalAIRequest
            {
                Model = "llama3.2:1b",
                Prompt = chatDetail.Source,
                Stream = false,
            };

            LocalAIResponse localAIResponse =
                await this.localAIApiRepository.PostLocalAIRequestAsync(localAIRequest);

            chatDetail.Content = localAIResponse.Response;
            await this.chatDetailRepository.UpdateChatDetailAsync(chatDetail);

            return chatDetail;
        }
    }
}
