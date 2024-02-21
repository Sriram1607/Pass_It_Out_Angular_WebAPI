using System.ComponentModel.DataAnnotations;

namespace Pass_It_Out_Angular_WebAPI.View_Models
{
    public class UserLoginVM
    {
        [Required(ErrorMessage = "UserId cannot be Empty!!!")]
        public string? UserId { set; get; }

        [Required(ErrorMessage = "Password cannot be empty!!!")]
        public string? Password { set; get; }
    }
}
