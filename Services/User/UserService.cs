using Pass_It_Out_Angular_WebAPI.Context;
using Pass_It_Out_Angular_WebAPI.Models;

namespace Pass_It_Out_Angular_WebAPI.Services.UserService
{
    public class UserService : IUser
    {
        private AppDbContext ctx;
        public UserService(AppDbContext ctx) 
        { 
            this.ctx = ctx;
        }

        public bool Registration(User user)
        {
            ctx.Users.Add(user);
            int rowsupdated=ctx.SaveChanges();
            return rowsupdated>0;
        }

        public bool Login(User user)
        {
            return true;
        }

        public User GetUserById(string id)
        {
           return ctx.Users.Where(val => val.UserId == id).FirstOrDefault();
        }

        public User IsUserExist(User user)
        {
            return ctx.Users.Where(val=>val.UserId==user.UserId && val.Password==user.Password).FirstOrDefault();
            
        }
    }
}
