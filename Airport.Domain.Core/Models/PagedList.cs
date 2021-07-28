using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Core.Models
{
    public class PagedList<T>
    {
        public int PagesCount { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public long TotalItems { get; }

        public IEnumerable<T> Items { get; }

        public PagedList(int pageNumber, int pageSize, long totalItemCount, IEnumerable<T> items)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.PagesCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
            this.TotalItems = totalItemCount;
            this.Items = items;
        }
    }
}
