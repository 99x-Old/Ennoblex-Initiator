using Ennoble_xController.DataAccess.unitOfWork.Collections;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ennoble_xController.DataAccess.unitOfWork
{
    public interface  IRepository<TEntity> where TEntity: class
    {
        IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, Object>> include = null,
            int pageIndex = 0,
            int pageSize = 20,
            bool disableTracking = true,
            bool ignoreQueryFilters = false
            );
        Task<IEnumerable<TEntity>> GetAll(
                   Expression<Func<TEntity, bool>> predicate =null,
                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderdby =null,
                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        ValueTask<TEntity> FindAsync(object[] values);
        void Update(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        void UpdateRange(IEnumerable<TEntity> entities);
      

    }
}
