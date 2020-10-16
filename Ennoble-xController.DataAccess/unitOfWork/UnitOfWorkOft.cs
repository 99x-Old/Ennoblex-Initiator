using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ennoble_xController.DataAccess.unitOfWork
{
    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext :DbContext
    {
        TContext DbContext { get; }
        Task<int> SaveChangesAsynch(params IUnitOfWork[] unitOfWorks);
    }
}
