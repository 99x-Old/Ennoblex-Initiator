using System;
using System.Collections.Generic;
using System.Text;

namespace Ennoble_xController.DataAccess.unitOfWork.Collections
{
   public interface IPagedList<T>
    {
        int IndexFrom { get; }
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        IList<T> Items { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }

    }
}
