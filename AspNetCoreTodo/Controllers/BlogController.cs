using Microsoft.AspNetCore.Mvc;
using Service;

namespace AspNetCoreTodo.Controllers
{
    /// <summary>
    /// 博客管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        // GET: api/Blog
        /// <summary>
        /// Sum 接口
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        [HttpGet]
        public int Get(int i, int j)
        {
            var service = new AdvertisementService();
            return service.Sum(i, j);
        }

        // GET: api/Blog/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
