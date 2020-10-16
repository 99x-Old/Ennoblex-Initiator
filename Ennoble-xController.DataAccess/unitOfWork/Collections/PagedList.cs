using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ennoble_xController.DataAccess.unitOfWork.Collections
{
    public class PagedList<T> : IPagedList<T>
    {
        internal PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int indexFrom) {

            if (indexFrom > pageIndex) throw new ArgumentException(
                $"indexfrom :{indexFrom}>pageIndex:{pageIndex}"
                );
            if (source is IQueryable<T> querable)
            {
                PageIndex = pageIndex;
                PageSize = pageSize;
                IndexFrom = indexFrom;
                TotalCount = source.Count();
                TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
                Items = querable.Skip((pageIndex - IndexFrom) * PageSize).Take(pageSize).ToList();
            }
            else 
            {
                PageIndex = pageIndex;
                PageSize = pageSize;
                IndexFrom = indexFrom;
                TotalCount = source.Count();
                TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
                Items = source.Skip((pageIndex - IndexFrom) * PageSize).Take(pageSize).ToList();

            }

        }
        internal PagedList() {
            Items = new T[0];
        }
        public int IndexFrom { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public IList<T> Items { get; set; }

        public bool HasPreviousPage => PageIndex-IndexFrom>0;

        public bool HasNextPage => PageIndex-IndexFrom +1 < TotalPages;
    }


}
