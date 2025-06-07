using System.Threading.Tasks;
using LocalMindApi.Models.UserAdditionalDetails;

namespace LocalMindApi.Repositories.UserAdditionalDetails
{
    public interface IUserAdditionalDetailRepository
    {
        ValueTask<UserAdditionalDetail> InsertUserAdditionalDetailAsync(
            UserAdditionalDetail userAdditionalDetail);
    }
}
