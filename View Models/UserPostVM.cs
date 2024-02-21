using System.ComponentModel.DataAnnotations;

namespace Pass_It_Out_Angular_WebAPI.View_Models
{
    public class UserPostVM
    {
        [Required(ErrorMessage = "Title cannot be Empty!!!")]
        public string? Title { set; get; }

        [Required(ErrorMessage = "Title cannot be Empty!!!")]
        public int CategoryId { set; get; }
        public string? Description { set; get; }
        public IFormFile Image { set; get; }

        public string? Location { set; get; }

        public string? PostTo { set; get; }

        [Required(ErrorMessage = "Creater Name cannot be Empty!!!")]
        public string? CreatedBy { set; get; }

        [Required(ErrorMessage = "Date cannot be Empty!!!")]
        public DateTime Createddate { set; get; }

        public bool Status { set; get; }
    }
}
