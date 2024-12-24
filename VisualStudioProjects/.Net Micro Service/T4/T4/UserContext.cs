using Microsoft.EntityFrameworkCore;

namespace T4
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) 
        { }
        public DbSet<User> Users { get; set; }
    }
}
