using System.Collections.Generic;
using System.Threading.Tasks;
using CdSite.Model.Model;

namespace CdSite.IService
{
    public interface IPostService : IBaseService<Post>
    {
        Task<List<Post>> GetPosts();
        Task<Post> GetPostById(int id);
    }
}