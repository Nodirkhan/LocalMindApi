using System;

namespace LocalMindApi.Models.UserTokens
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
