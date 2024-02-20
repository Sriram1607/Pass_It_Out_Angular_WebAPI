using Pass_It_Out_Angular_WebAPI.Models;

namespace Pass_It_Out_Angular_WebAPI.Services.Friends
{
    public interface IFriend
    {
        bool Save(Friend friend);
        List<Friend> GetAllFriends(string UserId);

        Friend GetFriendById(string UserId, string Id);

        List<Friend> GetFriendsById(string UserId, string Id);
        bool Update(Friend friend);

        List<Friend> GetAllSentRequests(string UserId);

        List<Friend> GetAllFriendRequests(string UserId);
    }
}
