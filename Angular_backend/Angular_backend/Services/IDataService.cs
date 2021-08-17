using Angular_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_backend.Services
{
    public interface IDataService
    {
        IEnumerable<BlogPost> GetBlogPosts();
      Task<BlogPost> GetBlogPost(int id);
        Task<BlogPost> PutBlogPost(int id, BlogPost blogPost);
        Task<BlogPost> PostBlogPost(BlogPost blogPost);
        Task<BlogPost> DeleteBlogPost(int id);
        bool BlogPostExists(int id);
    }
}
