using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.DataContext;
using LocalMindApi.Models.ChatDetails;

namespace LocalMindApi.Repositories.ChatDetails
{
    public class ChatDetailRepository : IChatDetailRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ChatDetailRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async ValueTask<ChatDetail> InsertChatDetailAsync(ChatDetail chatDetail)
        {
            await this.applicationDbContext.ChatDetails.AddAsync(chatDetail);
            await this.applicationDbContext.SaveChangesAsync();

            return chatDetail;
        }

        public IQueryable<ChatDetail> SelectAllChatDetails()
        {
            return this.applicationDbContext.ChatDetails
                .OrderByDescending(chatDetail => chatDetail.CreatedDate);
        }

        public async ValueTask<ChatDetail> UpdateChatDetailAsync(ChatDetail chatDetail)
        {
            this.applicationDbContext.Update(chatDetail);
            await this.applicationDbContext.SaveChangesAsync();

            return chatDetail;
        }
    }
}
