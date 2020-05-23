using AspNetCoreTodo.IRepository;
using AspNetCoreTodo.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(TEntity model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(TEntity model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteByIds(object[] ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> Query()
        {
            return await Task.Run(() => _context.Set<TEntity>().ToList());
        }

        public async Task<List<TEntity>> Query(string where)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await Task.Run(() => _context.Set<TEntity>().Where(whereExpression).ToList());
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFields)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> Query(string where, int top, string orderByFields)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int pageIndex, int pageSize, string orderByFields)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> Query(string where, string pageIndex, int pageSize, string orderByFields)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> QueryById(object id)
        {
            return await Task.Run(() => _context.Set<TEntity>().Find(id));
        }

        public async Task<TEntity> QueryById(object id, bool inUseCache = false)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> QueryByIds(object[] ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int pageIndex = 0, int pageSize = 20, string orderByFields = null)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(TEntity model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(TEntity model, string where)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(TEntity model, List<string> columns = null, List<string> ignoreColumns = null, string where = "")
        {
            throw new NotImplementedException();
        }
    }
}
