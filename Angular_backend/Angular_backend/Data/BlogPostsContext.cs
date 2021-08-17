using Microsoft.EntityFrameworkCore;

namespace Angular_backend.Data
{
    public class BlogPostsContext : DbContext
    {
        public BlogPostsContext(DbContextOptions<BlogPostsContext> options)
            : base(options)
        {
        }

        public DbSet<Angular_backend.Models.BlogPost> BlogPosts { get; set; }
    }
}
