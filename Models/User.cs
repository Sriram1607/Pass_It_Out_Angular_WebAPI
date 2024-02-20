using System.ComponentModel.DataAnnotations;

namespace Pass_It_Out_Angular_WebAPI.Models
{
    public class User
    {
        public string? UserId { set; get; }
        public string? FirstName { set; get; }
        public string? LastName { set; get; } 
        public string? Email { set; get; }
        public string? Location { set; get; }

        public string? Password { set; get; }
    }
}
