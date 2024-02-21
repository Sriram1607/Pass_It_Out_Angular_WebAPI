using Pass_It_Out_Angular_WebAPI.Models;
using Pass_It_Out_Angular_WebAPI.View_Models;

namespace Pass_It_Out_Angular_WebAPI.Services.Posts
{
    public interface IPost
    {
        bool Save(Post post);
        List<Post> GetAllPosts(string UserId);
        List<Post> MyPosts(string UserId);

        List<Category> GetAllCategories();

        Post GetPostById(string id);

        bool Update(Post post);
        bool Delete(Post post);

    }
}
