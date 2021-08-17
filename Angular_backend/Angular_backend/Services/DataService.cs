using Angular_backend.Data;
using Angular_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_backend.Services
{
    public class DataService:IDataService
    {
        private readonly BlogPostsContext _context;
        private readonly IDataRepository<BlogPost> _repo;
        public DataService(BlogPostsContext context, IDataRepository<BlogPost> repo)
        {
            _context = context;
            _repo = repo;
        }
        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return _context.BlogPosts.OrderByDescending(p => p.PostId);
        }
        public async Task<BlogPost> GetBlogPost( int id)
        {
            return await _context.BlogPosts.FindAsync(id);
        }
        public async Task<BlogPost> PutBlogPost(int id,  BlogPost blogPost)
        {
            _context.Entry(blogPost).State = EntityState.Modified;
            _repo.Update(blogPost);
                var save = await _repo.SaveAsync(blogPost);

            return save;
        }
        public async Task<BlogPost> PostBlogPost(BlogPost blogPost)
        {
            _repo.Add(blogPost);
            var save = await _repo.SaveAsync(blogPost);
            return save;
        }
        public async Task<BlogPost> DeleteBlogPost(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            _repo.Delete(blogPost);
            var save = await _repo.SaveAsync(blogPost);
            return blogPost;
        }
        public bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.PostId == id);
        }
    }
}
