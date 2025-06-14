﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LocalMindApi.Models.Chats;
using LocalMindApi.Models.UserAdditionalDetails;

namespace LocalMindApi.Models.Users
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public Role Role { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public UserAdditionalDetail UserAdditionalDetail { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
    }
}
