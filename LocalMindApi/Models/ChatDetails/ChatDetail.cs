using System;
using LocalMindApi.Models.Chats;

namespace LocalMindApi.Models.ChatDetails
{
    public class ChatDetail
    {
        public Guid Id { get; set; }
        public string Source { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
