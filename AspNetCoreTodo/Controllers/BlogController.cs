using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Service;
using System.Collections.Generic;
using AspNetCoreTodo.Model.Model;
using AspNetCoreTodo.Repository.Data;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Controllers
{
    /// <summary>
    /// 博客管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly PostService _postService;

        public BlogController(ApplicationDbContext context)
        {
            _postService = new PostService(context);
        }

        // GET: api/Blog
        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Post>> Get()
        {
            return await _postService.GetBlogs();
        }

        // GET: api/Blog/5
        /// <summary>
        /// 根据 id 获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<Post> Get(int id)
        {
            return await _postService.GetPostById(id);
        }

        // POST: api/Blog
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
