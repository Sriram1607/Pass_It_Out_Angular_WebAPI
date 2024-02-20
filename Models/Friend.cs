namespace Pass_It_Out_Angular_WebAPI.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? FriendId { get; set; }
        public string? Status { get; set; }

        public DateTime RequestedDate { set; get; }
        public DateTime ConfirmedDate { set; get; }
    }
}
