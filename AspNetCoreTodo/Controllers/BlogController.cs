using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Service;
using System.Collections.Generic;
using AspNetCoreTodo.Model.Model;

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
        //[HttpGet]
        //public int Get(int i, int j)
        //{
        //    var service = new AdvertisementService();
        //    return service.Sum(i, j);
        //}

        // GET: api/Blog
        [HttpGet]
        public List<ArticalAbstract> Get()
        {
            return new List<ArticalAbstract>
            {
                new ArticalAbstract
                {
                    Title = "No Code 趋势小记",
                    AbstractMessage = "前一阵子听说了一个新鲜词 No Code。直译过来就是“无码”嘛，所以第一反应是冯大辉（Fenng）的公司，然而这里写的并不是这个 >_<",
                    Url = "https://cd-yang.com/2020/03/No-Code-%E8%B6%8B%E5%8A%BF%E5%B0%8F%E8%AE%B0/"
                },
                new ArticalAbstract
                {
                    Title = "Electron中require报错的解决与分析",
                    AbstractMessage = "环境：Electron 7 使用 Create-React-App 模板 运行时发生的错误：",
                    Url = "https://cd-yang.com/2020/03/Electron%E4%B8%ADrequire%E6%8A%A5%E9%94%99%E7%9A%84%E8%A7%A3%E5%86%B3%E4%B8%8E%E5%88%86%E6%9E%90/"
                }
            };
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
