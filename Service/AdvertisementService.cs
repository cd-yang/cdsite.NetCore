using IRepository;
using IService;
using Repository;

namespace Service
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
