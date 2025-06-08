using System.ComponentModel.DataAnnotations;
using LocalMindApi.Models.UserAdditionalDetails;
using LocalMindApi.Models.Users;

namespace LocalMindApi.DTOs
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public Role Role { get; set; }

        public UserAdditionalDetail UserAdditionalDetail { get; set; }
    }
}
