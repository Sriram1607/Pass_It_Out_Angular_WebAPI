using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pass_It_Out_Angular_WebAPI.Models;
using Pass_It_Out_Angular_WebAPI.Services.Posts;
using Pass_It_Out_Angular_WebAPI.View_Models;

namespace Pass_It_Out_Angular_WebAPI.Controllers.Posts
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPost postservice;
        public PostController(IPost postservice) 
        { 
            this.postservice = postservice;
        }
        [HttpPost]
        [Route("Save")]
        public bool Save([FromForm]UserPostVM userPostVM)
        {
            Post newpost = new Post();

            //newpost.UserId=

            newpost.Title = userPostVM.Title;
            newpost.CategoryId = userPostVM.CategoryId;
            newpost.Description = userPostVM.Description;
            newpost.Image = GetImageBytes(userPostVM.Image);
            newpost.Location = userPostVM.Location;
            newpost.PostTo = userPostVM.PostTo;
            newpost.CreatedBy = userPostVM.CreatedBy;
            newpost.CreatedDate = userPostVM.Createddate;
            newpost.Status = userPostVM.Status;
            bool flag = postservice.Save(newpost);
            return flag;
        }

        [NonAction]
        public byte[] GetImageBytes(IFormFile Image)
        {
            byte[] ImageByteData = null;
            if(Image!=null && Image.Length>0)
            {
                using (var stream=Image.OpenReadStream())
                {
                    ImageByteData = new byte[stream.Length];
                    stream.Read(ImageByteData,0,ImageByteData.Length);
                }
            }
            return ImageByteData;
        }
    }
}
