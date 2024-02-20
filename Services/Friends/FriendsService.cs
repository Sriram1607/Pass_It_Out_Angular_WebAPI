using Pass_It_Out_Angular_WebAPI.Context;
using Pass_It_Out_Angular_WebAPI.Models;

namespace Pass_It_Out_Angular_WebAPI.Services.Friends
{
    public class FriendsService : IFriend
    {
        private AppDbContext ctx;
        public FriendsService(AppDbContext ctx) 
        { 
            this.ctx= ctx;
        }
        public List<Friend> GetAllFriendRequests(string UserId)
        {
            List<Friend> friendrequests = ctx.Friends.Where(val=>val.FriendId==UserId).ToList();
            return friendrequests;
        }

        public List<Friend> GetAllFriends(string UserId)
        {
            List<Friend> friends=ctx.Friends.Where(val=>val.UserId==UserId && val.Status=="Accepted").ToList(); 
            return friends;
        }

        public List<Friend> GetAllSentRequests(string UserId)
        {
            List<Friend> sentrequests=ctx.Friends
                .Where(val=>val.UserId==UserId)
                .Select(val=>new Friend
                {
                    FriendId = val.FriendId,
                    Status = val.Status,
                    RequestedDate = val.RequestedDate,
                    ConfirmedDate = val.ConfirmedDate,
                }).ToList();
            return sentrequests; ;
        }

        public Friend GetFriendById(string UserId, string Id)
        {
            Friend friend = ctx.Friends.Where(val => val.UserId == Id && val.FriendId == UserId).FirstOrDefault();
            return friend;
        }

        public List<Friend> GetFriendsById(string UserId, string Id)
        {
            List<Friend> friends = ctx.Friends.Where(val => val.UserId == Id && val.FriendId == UserId).ToList();
            return friends;
        }

        public bool Save(Friend friend)
        {
            ctx.Friends.Add(friend);
            return ctx.SaveChanges() > 0;
        }

        public bool Update(Friend friend)
        {
            ctx.Friends.Update(friend);
            return ctx.SaveChanges() > 0;
        }
    }
}
