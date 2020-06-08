using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CdSite.IService
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity> QueryById(object id);
        Task<TEntity> QueryById(object id, bool inUseCache = false);
        Task<List<TEntity>> QueryByIds(object[] ids);

        Task<int> Add(TEntity model);

        Task<bool> Delete(TEntity model);
        Task<bool> DeleteById(object id);
        Task<bool> DeleteByIds(object[] ids);

        Task<bool> Update(TEntity model);
        Task<bool> Update(TEntity model, string where);
        Task<bool> Update(TEntity model,
                          List<string> columns = null,
                          List<string> ignoreColumns = null,
                          string where = "");

        Task<List<TEntity>> Query();
        Task<List<TEntity>> Query(string where);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression,
                                  string strOrderByFields);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression,
                                  Expression<Func<TEntity, object>> orderByExpression,
                                  bool isAsc = true);
        Task<List<TEntity>> Query(string where, int top, string orderByFields);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression,
                                  int pageIndex,
                                  int pageSize,
                                  string orderByFields);
        Task<List<TEntity>> Query(string where,
                                  string pageIndex,
                                  int pageSize,
                                  string orderByFields);

        Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression,
                                      int pageIndex = 0,
                                      int pageSize = 20,
                                      string orderByFields = null);
    }
}