using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChatApp.Models
{
    public class ChatContext: DbContext
    {
        public ChatContext() : base("Con")
        {

        }
        public static ChatContext Create()
        {
            return new ChatContext();
        }

        public DbSet<User> Users { get; set; }
    }
}