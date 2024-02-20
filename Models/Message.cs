namespace Pass_It_Out_Angular_WebAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? UserId { set; get; }

        public string? To { set; get; }
        public string? TextMessage { set; get; }
    }
}
