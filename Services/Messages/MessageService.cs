using Pass_It_Out_Angular_WebAPI.Context;
using Pass_It_Out_Angular_WebAPI.Models;

namespace Pass_It_Out_Angular_WebAPI.Services.Messages
{
    public class MessageService : IMessage
    {
        private AppDbContext ctx;
        public MessageService(AppDbContext ctx) 
        {
            this.ctx = ctx;
        }
        public List<Message> GetAllMessages(string id)
        {
            return ctx.Messages.ToList();
        }

        public bool Save(Message message)
        {
            ctx.Messages.Add(message);
            return ctx.SaveChanges()>0;
        }
    }
}
