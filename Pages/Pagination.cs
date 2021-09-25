using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_CRUD.Data
{
    public class Pagination<T> : List<T>
    {
        public int TotalPages {get; private set; }
        public int PageIndex {get; private set; }

        public Pagination(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage()
        {
            return PageIndex > 1;
        }

        public bool HasNextPage() 
        {
            return PageIndex < TotalPages;
        }

        public static async Task<Pagination<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize).ToListAsync();
            
            return new Pagination<T>(items, count, pageIndex, pageSize);
        }
    }
}