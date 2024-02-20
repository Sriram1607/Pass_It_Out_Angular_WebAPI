using Pass_It_Out_Angular_WebAPI.Models;

namespace Pass_It_Out_Angular_WebAPI.Services.UserService
{
    public interface IUser
    {
        bool Login(User user);
        bool Registration(User user);

        User GetUserById(string id);
        User IsUserExist(User user);
    }
}
