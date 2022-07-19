using Microsoft.EntityFrameworkCore;

namespace BlogFinalProject.Models
{
    public class BlogUserContext : DbContext
    {
        public BlogUserContext(DbContextOptions<BlogUserContext> options)
            : base(options)
        {
        }
        public DbSet<BlogUser> BlogUsers { get; set; }
    }
   
}
