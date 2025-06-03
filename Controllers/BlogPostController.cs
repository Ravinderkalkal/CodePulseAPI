using Azure;
using CodePurse.API.Data;
using CodePurse.API.Models.Domain;
using CodePurse.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodePurse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public BlogPostController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateblogPost(CreateBlogPostRequest createBlogPostRequest) {

            try
            {
                BlogPost blogPost = new BlogPost();
                blogPost.Title = createBlogPostRequest.Title;
                blogPost.ShortDescription = createBlogPostRequest.ShortDescription;
                blogPost.Author = createBlogPostRequest.Author;
                blogPost.Content = createBlogPostRequest.Content;
                blogPost.ShortDescription = createBlogPostRequest.ShortDescription;
                blogPost.FeaturedImageUrl = createBlogPostRequest.FeaturedImageUrl;
                blogPost.IsVisible = createBlogPostRequest.IsVisible;
                blogPost.PublishedDate = createBlogPostRequest.PublishedDate;
                blogPost.IsVisible = createBlogPostRequest.IsVisible;
                blogPost.UrlHandle = "createBlogPostRequest.IsVisible";

                await dBContext.BlogPosts.AddAsync(blogPost);
                await dBContext.SaveChangesAsync();

                var response = blogPost;

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Optionally log the exception here using a logger
                return StatusCode(500, "An error occurred while retrieving blog posts.");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            try
            {
                var response = dBContext.BlogPosts.ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Optionally log the exception here using a logger
                return StatusCode(500, "An error occurred while retrieving blog posts.");
            }
        }




        //// GET: api/<BlogPostController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<BlogPostController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<BlogPostController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<BlogPostController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BlogPostController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
