using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Repository.Data;
using AspNetCoreTodo.IService;
using System.Collections.Generic;
using System.Linq.Expressions;
using AspNetCoreTodo.IRepository;
using Repository;

namespace AspNetCoreTodo.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> baseDal;

        public BaseService(ApplicationDbContext context)
        {
            baseDal = new BaseRepository<TEntity>(context);
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
            return await baseDal.Query();
        }

        public async Task<List<TEntity>> Query(string where)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await baseDal.Query(whereExpression);
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

        /// <summary>
        /// 根据 ID 查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> QueryById(object id)
        {
            return await baseDal.QueryById(id);
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