using System;
using System.Collections.Generic;
using System.Text;

namespace Ennoble_xController.DataAccess.unitOfWork.Collections
{
    public static class PagedListExtentionsForIEnumerable
    {
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSie, int indexFrom = 0) {

            return new PagedList<T>(source, pageIndex, pageSie, indexFrom);
        
        }
    }
}
