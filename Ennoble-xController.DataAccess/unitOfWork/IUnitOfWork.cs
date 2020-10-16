using System;
using System.Collections.Generic;
using System.Text;

namespace Ennoble_xController.DataAccess.unitOfWork
{
   public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int SaveChanges();
        int SaveChangesAsync();
    }
}
