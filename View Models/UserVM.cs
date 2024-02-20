using System.ComponentModel.DataAnnotations;

namespace Pass_It_Out_Angular_WebAPI.View_Models
{
    public class UserVM
    {
        [Required(ErrorMessage ="UserId cannot be Empty!!!")]
        public string? UserId { set; get; }

        [Required (ErrorMessage ="First Name should have minimum of 5 charecters!!!")]
        [MinLength(5)]
        public string? FirstName { set; get; }

        [Required(ErrorMessage = "Last Name should have minimum of 5 charecters!!!")]
        [MinLength(5)]
        public string? LastName { set; get; }

        [Required(ErrorMessage ="Email cannot be empty!!!")]
        public string? Email { set; get; }
        public string? Location { set; get; }

        [Required (ErrorMessage ="Password cannot be empty!!!")]
        public string? Password { set; get; }
        public string? ConfirmPassword { set; get; }

    }
}
