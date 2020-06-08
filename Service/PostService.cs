using CdSite.Repository.Data;
using CdSite.IService;
using CdSite.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CdSite.Service
{
    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// 根据 Id 获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Post> GetPostById(int id)
        {
            return await base.QueryById(id);
        }

        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Post>> GetPosts()
        {
            return await base.Query(a => a.Id > 0);
        }
    }
}
