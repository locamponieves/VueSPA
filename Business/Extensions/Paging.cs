using Business.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class Paging
    {
        public static async Task<DataCollections<T>> PagedAsync<T>(
            this IQueryable<T> query,
            int page,
            int take
        ) where T : class
        {
            var result = new DataCollections<T>();

            result.Total = await query.CountAsync();

            result.Page = page;

            if(result.Total > 0)
            {
                result.Pages = Convert.ToInt32(
                    Math.Ceiling(
                        Convert.ToDecimal(result.Total) / take
                    )
                );

                result.Items = await query.Skip((page - 1) * take)
                    .Take(take)
                    .ToListAsync();
            }

            return result;
        }
    }
}