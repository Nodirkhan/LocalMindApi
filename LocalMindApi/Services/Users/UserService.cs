using System;
using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.Models.Users;
using LocalMindApi.Repositories.UserAdditionalDetails;
using LocalMindApi.Repositories.Users;

namespace LocalMindApi.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserAdditionalDetailRepository userAdditionalDetailRepository;

        public UserService(
            IUserRepository userRepository,
            IUserAdditionalDetailRepository userAdditionalDetailRepository)
        {
            this.userRepository = userRepository;
            this.userAdditionalDetailRepository = userAdditionalDetailRepository;
        }

        public async ValueTask<User> AddUserAsync(User user)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            user.CreatedDate = now;
            user.UpdatedDate = now;

            await this.userRepository.InsertUserAsync(user);

            if (user.UserAdditionalDetail != null)
            {
                await this.userAdditionalDetailRepository
                    .InsertUserAdditionalDetailAsync(user.UserAdditionalDetail);
            }

            return user;
        }

        public IQueryable<User> RetrieveAllUsers()
        {
            return this.userRepository.SelectAllUsers();
        }
    }
}
