using Microsoft.EntityFrameworkCore;

namespace SignalR_Chat
{
    public class MessageContext:DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options)
               : base(options)
        {
            Database.EnsureCreated();
        }
        DbSet<Message> Messages { get; set; }
    }
}
