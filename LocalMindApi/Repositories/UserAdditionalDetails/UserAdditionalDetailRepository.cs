using System.Threading.Tasks;
using LocalMindApi.DataContext;
using LocalMindApi.Models.UserAdditionalDetails;

namespace LocalMindApi.Repositories.UserAdditionalDetails
{
    public class UserAdditionalDetailRepository : IUserAdditionalDetailRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserAdditionalDetailRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async ValueTask<UserAdditionalDetail> InsertUserAdditionalDetailAsync(
            UserAdditionalDetail userAdditionalDetail)
        {
            await this.applicationDbContext.UserAdditionalDetails.AddAsync(userAdditionalDetail);

            return userAdditionalDetail;
        }
    }
}
