using System;
using System.Collections.Generic;
using LocalMindApi.Models.ChatDetails;
using LocalMindApi.Models.Users;

namespace LocalMindApi.Models.Chats
{
    public class Chat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<ChatDetail> ChatDetails { get; set; }
    }
}
