using AspNetCoreTodo.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AspNetCoreTodo.IRepository;

namespace AspNetCoreTodo.Repository
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        public int Add(Advertisement model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Advertisement model)
        {
            throw new NotImplementedException();
        }

        public List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression)
        {
            throw new NotImplementedException();
        }

        public int Sum(int i, int j)
        {
            return i + j;
        }

        public bool Update(Advertisement model)
        {
            throw new NotImplementedException();
        }
    }
}
