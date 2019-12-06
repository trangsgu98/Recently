using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Examining
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(IEnumerable<T> source, int pageIndex, int pageSize,int count)
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            
            this.AddRange(source);
        }

        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public bool HasNext
        {
            get { return PageIndex < TotalPage; }
        }
        public bool HasPrevious
        {
            get { return PageIndex > 1; }
        }

         public static  async Task<PaginatedList<T>> CreateAsync(IQueryable<T> query, int pageIndex, int pageSize)
        {
            //int count = await query.CountAsync<T>();
            var count = await query.CountAsync<T>();

            var items = await query.Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, pageIndex, pageSize, count);
        }
    }
}