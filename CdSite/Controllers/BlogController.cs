using Microsoft.AspNetCore.Mvc;
using CdSite.Model.Model;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CdSite.IService;
using CdSite.Model;
using CdSite.Model.ViewModel;

namespace CdSite.Controllers
{
    /// <summary>
    /// 博客管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IPostService _postService;

        public BlogController(ILogger<BlogController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        // GET: api/Blog
        /// <summary>
        /// 按 page 获取文章
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<PageModel<Post>>> Get(int id, int page = 1)
        {
            var posts = await _postService.GetPosts();
            return new MessageModel<PageModel<Post>>()
            {
                Success = true,
                Msg = "获取成功",
                Response = new PageModel<Post>()
                {
                    Page = page,
                    DataCount = posts.Count,
                    Data = posts,
                    PageCount = 5,  // TODO: 换成真实页数
                }
            };
        }

        // GET: api/Blog/5
        /// <summary>
        /// 根据 id 获取 Post 页面数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<MessageModel<PostViewModel>> Get(int id)
        {
            var post = await _postService.GetPostById(id);
            if (post != null)
                return new MessageModel<PostViewModel>()
                {
                    Success = true,
                    Msg = "获取成功",
                    Response = new PostViewModel()
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Content = post.Content,
                        CreateOnUtc = post.CreateOnUtc,
                        PubDateUtc = post.PubDateUtc ?? post.CreateOnUtc,
                        Previous = "123",
                        PreviousId = 1,
                        Next = "qwer",
                        NextId = 3
                    }
                };
            else
                return new MessageModel<PostViewModel>
                {
                    Success = false,
                    Msg = "未获取到该文章"
                };
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
