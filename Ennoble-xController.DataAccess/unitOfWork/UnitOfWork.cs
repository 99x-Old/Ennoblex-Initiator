using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ennoble_xController.DataAccess.unitOfWork
{
    class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        public UnitOfWork(TContext context)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public TContext DbContext { get; set; }
        public Dictionary<Type, object> Repositories { get; private set; }
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (Repositories == null) Repositories = new Dictionary<Type, Object>();

            var type = typeof(TEntity);
            if (!Repositories.ContainsKey(type)) Repositories[type] = new Repository<TEntity>(DbContext);
            return (IRepository<TEntity>)Repositories[type];
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsynch(params IUnitOfWork[] unitOfWorks)
        {
            throw new NotImplementedException();
        }

        int IUnitOfWork.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
