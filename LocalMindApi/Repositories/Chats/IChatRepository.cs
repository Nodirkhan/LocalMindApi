using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.Models.Chats;

namespace LocalMindApi.Repositories.Chats
{
    public interface IChatRepository
    {
        ValueTask<Chat> InsertChatAsync(Chat chat);
        IQueryable<Chat> SelectAllChats();
    }
}
