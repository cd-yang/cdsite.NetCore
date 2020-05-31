using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Model.Model;

namespace AspNetCoreTodo.IService
{
    public interface IPostService : IBaseService<Post>
    {
        Task<List<Post>> GetPosts();
        Task<Post> GetPostById(int id);
    }
}