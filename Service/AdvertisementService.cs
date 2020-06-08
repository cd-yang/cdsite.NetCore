using CdSite.IRepository;
using CdSite.IService;
using CdSite.Repository;

namespace CdSite.Service
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
