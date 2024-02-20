using Microsoft.EntityFrameworkCore;
using Pass_It_Out_Angular_WebAPI.Models;

namespace Pass_It_Out_Angular_WebAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
