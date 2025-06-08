using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.DataContext;
using LocalMindApi.Models.Chats;
using LocalMindApi.Repositories.Chats;

namespace LocalMindApi.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ChatRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async ValueTask<Chat> InsertChatAsync(Chat chat)
        {
            await this.dbContext.Chats.AddAsync(chat);
            await this.dbContext.SaveChangesAsync();

            return chat;
        }

        public IQueryable<Chat> SelectAllChats()
        {
            return this.dbContext.Chats;
        }
    }
}
