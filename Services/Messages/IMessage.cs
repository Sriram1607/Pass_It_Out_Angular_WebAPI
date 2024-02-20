using Pass_It_Out_Angular_WebAPI.Models;

namespace Pass_It_Out_Angular_WebAPI.Services.Messages
{
    public interface IMessage
    {
        bool Save(Message message);
        List<Message> GetAllMessages(string id);
    }
}
