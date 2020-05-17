using AspNetCoreTodo.IRepository;
using AspNetCoreTodo.IService;
using AspNetCoreTodo.Repository;

namespace AspNetCoreTodo.Service
{
    public class AdvertisementService : IAdvertisementService
    {
        IAdvertisementRepository dal = new AdvertisementRepository();

        public int Sum(int i, int j)
        {
            return dal.Sum(i, j);
        }
    }
}
