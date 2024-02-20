namespace Pass_It_Out_Angular_WebAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? UserId { get; set; }

        public string? Title { get; set; }

        public int CategoryId { set; get; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }

        public string? Location { set; get; }
        public string? PostTo { set; get; }

        public string? CreatedBy { set; get;}
        public DateTime CreatedDate { set; get; }

        public bool Status { set; get; }

    }
}
