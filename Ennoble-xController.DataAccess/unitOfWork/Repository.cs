using Ennoble_xController.DataAccess.unitOfWork.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ennoble_xController.DataAccess.unitOfWork
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
    
        public Repository(DbContext dbContext) {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<TEntity>();
        }

        public async ValueTask<TEntity> FindAsync(object[] values)
        {
            return await _dbSet.FindAsync(values);
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderdby = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = QueryProcess(predicate, include);
            if (orderdby != null) await orderdby(query).ToListAsync();
            return await query.ToListAsync();
        }

        public IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>,
        IOrderedQueryable<TEntity>> orderby = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        int pageIndex = 0, int pageSize = 20, bool disableTracking = true, bool ignoreQueryFilters = false)
        {
            var query = QueryProcess(predicate, include, disableTracking, ignoreQueryFilters);
            if (orderby != null) {
                return orderby(query).ToPagedList(pageIndex, pageSize);
            }
            return query.ToPagedList(pageIndex, pageSize);
        }

        public  IQueryable<TEntity> QueryProcess(
                Expression<Func<TEntity, bool>> predicate = null,
                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                bool disableTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking) {
                query.AsNoTracking();
            }

            if (include != null) query = include(query);
            if (predicate != null) query = query.Where(predicate);
            if (ignoreQueryFilters) query = query.IgnoreQueryFilters();
            return query;

        }

        public void Update(TEntity entity)
        {
             _dbSet.Update(entity);

        }
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange();
        }

        public Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
