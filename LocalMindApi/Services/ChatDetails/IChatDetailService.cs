using System;
using System.Threading.Tasks;
using LocalMindApi.Models.ChatDetails;

namespace LocalMindApi.Services.ChatDetails
{
    public interface IChatDetailService
    {
        ValueTask<ChatDetail> AddChatDetailsAsync(ChatDetail chatDetail, Guid userId);
    }
}
