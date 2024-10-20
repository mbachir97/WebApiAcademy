using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AcademiProject.Core.Wrapper
{
    public static class QuerableExtention
    {
        public async static Task<PaginateResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> sourse , int pagenumber , int pagesize )
            where T : class 
        {
            
            if( sourse == null )    throw new ArgumentNullException("the sourse is nullable");

                pagenumber = pagenumber <=1 ? 1 : pagenumber;    
                pagesize = pagesize == 0 ? 10 : pagesize;       
            
            int count = await  sourse.AsNoTracking().CountAsync(); 
            if (count == 0) return PaginateResult<T>.Success(new List<T>() , count , pagenumber , pagesize); 

            var items = await sourse.Skip((pagenumber - 1)*pagesize).Take(pagesize).ToListAsync(); 

            return PaginateResult<T>.Success(items, count, pagenumber, pagesize);

        }
       
    }
}
