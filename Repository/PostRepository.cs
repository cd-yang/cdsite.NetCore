using CdSite.IRepository;
using CdSite.Model.Model;
using CdSite.Repository.Data;
using Repository;

namespace CdSite.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
