using System;
using System.Linq;
using System.Threading.Tasks;
using LocalMindApi.DTOs;
using LocalMindApi.Helpers;
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

        public async ValueTask<UserDTO> AddUserAsync(UserDTO userDTO)
        {
            User newUser = MapToUserOnAdd(userDTO);

            newUser.HashedPassword = HashingHelper.GetHash(
                input: newUser.HashedPassword);

            await this.userRepository.InsertUserAsync(newUser);

            if (newUser.UserAdditionalDetail != null)
            {
                await this.userAdditionalDetailRepository
                    .InsertUserAdditionalDetailAsync(newUser.UserAdditionalDetail);
            }

            return userDTO;
        }

        public IQueryable<UserDTO> RetrieveAllUsers()
        {
            return this.userRepository.SelectAllUsers()
                .Select(MapToUserDTO)
                    .AsQueryable();
        }

        private static UserDTO MapToUserDTO(User user)
        {
            return new UserDTO
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                UserAdditionalDetail = user.UserAdditionalDetail
            };
        }

        private static User MapToUserOnAdd(UserDTO userDTO)
        {
            Guid newId = Guid.NewGuid();
            DateTimeOffset now = DateTimeOffset.UtcNow;

            return new User
            {
                Id = newId,
                Username = userDTO.Username,
                HashedPassword = userDTO.Password, // This will be hashed later
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                PhoneNumber = userDTO.PhoneNumber,
                Role = userDTO.Role,
                CreatedDate = now,
                UpdatedDate = now,
                UserAdditionalDetail = userDTO.UserAdditionalDetail
            };
        }
    }
}
