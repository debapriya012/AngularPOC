using Angular_backend.Data;
using Angular_backend.Models;
using Angular_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_backend.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {

        private readonly IDataService service;
        public BlogPostsController(IDataService service)
        {
            this.service = service;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public IEnumerable<BlogPost> GetBlogPosts()
        {

            return service.GetBlogPosts();
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var blogPost = await service.GetBlogPost(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return Ok(blogPost);
        }

        // PUT: api/BlogPosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost([FromRoute] int id, [FromBody] BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blogPost.PostId)
            {
                return BadRequest();
            }



            try
            {

                await service.PutBlogPost(id, blogPost);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Content(EntityState.Modified.ToString());
        }

        // POST: api/BlogPosts
        [HttpPost]
        public async Task<IActionResult> PostBlogPost([FromBody] BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await service.PostBlogPost(blogPost);

            return CreatedAtAction("GetBlogPost", new { id = blogPost.PostId }, blogPost);
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var blogPost = await service.GetBlogPost(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            await service.DeleteBlogPost(id);

            return Ok(blogPost);
        }

        private bool BlogPostExists(int id)
        {

            var data = service.BlogPostExists(id);
            return data;
        }
    }
}
