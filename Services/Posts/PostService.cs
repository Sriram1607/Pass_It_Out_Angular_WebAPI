using Pass_It_Out_Angular_WebAPI.Context;
using Pass_It_Out_Angular_WebAPI.Models;
using Pass_It_Out_Angular_WebAPI.View_Models;

namespace Pass_It_Out_Angular_WebAPI.Services.Posts
{
    public class PostService : IPost
    {
        private AppDbContext ctx;

        public PostService(AppDbContext ctx)
        {
            this.ctx = ctx;
        }
        public List<Category> GetAllCategories()
        {
            return ctx.Categories.ToList();
        }

        public List<Post> GetAllPosts(string UserId)
        {
            return ctx.Posts.ToList();
        }

        public Post GetPostById(string id)
        {
            return ctx.Posts.Where(val=>val.UserId==id).FirstOrDefault();
        }

        public List<Post> MyPosts(string UserId)
        {
            return ctx.Posts.Where(val => val.UserId==UserId).ToList();
        }

        public bool Save(UserPostVM post)
        {
            Post newpost = new Post();
            newpost.Title = post.Title;
            newpost.CategoryId=post.CategoryId;
            newpost.Description = post.Description;
            //newpost.Image = post.Image;
            newpost.Location=post.Location;
            newpost.PostTo=post.PostTo;
            newpost.CreatedBy=post.CreatedBy;
            newpost.CreatedDate = post.Createddate;
            newpost.Status = post.Status;
            int rowsupdated = ctx.SaveChanges();
            return rowsupdated>0;
        }

        public bool Update(Post post)
        {
            Post updatepost = GetPostById(post.UserId);
            updatepost.Title = post.Title;
            updatepost.Title = post.Title;
            updatepost.CategoryId = post.CategoryId;
            updatepost.Description = post.Description;
            //newpost.Image = post.Image;
            updatepost.Location = post.Location;
            updatepost.PostTo = post.PostTo;
            updatepost.CreatedBy = post.CreatedBy;
            updatepost.CreatedDate = post.CreatedDate;
            updatepost.Status = post.Status;
            ctx.Posts.Update(updatepost);
            int rowsupdated = ctx.SaveChanges();
            return rowsupdated>0;
        }

        public bool Delete(Post post)
        {
            Post deletepost=GetPostById(post.UserId);
            ctx.Posts.Remove(deletepost);
            int rowsupdated=ctx.SaveChanges();
            return rowsupdated>0;
        }
    }
}
