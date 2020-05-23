using AspNetCoreTodo.IRepository;
using AspNetCoreTodo.Model.Model;
using AspNetCoreTodo.Repository.Data;
using Repository;

namespace AspNetCoreTodo.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
