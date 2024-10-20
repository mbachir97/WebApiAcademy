using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPaternWithUOW.Core.Interfaces;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using RepositoryPaternWithUOW.Core.Const;
using System.Collections.Specialized;

namespace RepositoryPaternWithUOW.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public T GetById(int id)
        {
           
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public async Task<IEnumerable<T>> GetAllAsync(string[] Includes = null)
        {
            IQueryable<T> querie = _context.Set<T>(); 
            if(Includes != null)
            {
                foreach (var item in Includes)
                {
                    querie = querie.Include(item);      
                }
            }  
            return await querie.ToListAsync();
        }

        public IQueryable<T> GetTableNoTracking()
        {
            return _context.Set<T>().AsNoTracking();    
        }
        public IQueryable<T> GetTableTracking()
        {
            return _context.Set<T>().AsTracking() ;
        }

        public async Task<T> AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);  
           await _context.SaveChangesAsync();
            return entity; 
        }

        public async Task AddRangeAsync(ICollection<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);    
            await _context.SaveChangesAsync();  
        }
        
        public async Task<T> UpdateAsync(T entiy)
        {
             _context.Set<T>().Update(entiy); 
            await _context.SaveChangesAsync();  
            return entiy;   
        }
        
        public async Task DeleteAsync(T entity)
        {
             _context.Set<T>().Remove(entity);    
            await _context.SaveChangesAsync();  
        }

       

        public  T Find(Expression<Func<T, bool>> critiria)
        {
            return   _context.Set<T>().SingleOrDefault(critiria);   
        }

        public async  Task<T> FindAsync(Expression<Func<T, bool>> critiria , string[] Includes = null)
        {
            IQueryable<T> querie = _context.Set<T>();
            if (Includes != null)
            {
                foreach (var include in Includes)
                {
                    querie = querie.Include(include);
                }

            }
            return await querie.SingleOrDefaultAsync(critiria);
        }
      
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> critiria, string[] Includes )
        {
            IQueryable<T> querie = _context.Set<T>();
            if (Includes != null)
            {
                foreach (var include in Includes)
                {
                    querie = querie.Include(include);
                }

            }
            return await querie.Where(critiria).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> critiria,int skip = 0 , int take = 10)
        {
            
         
            return await _context.Set<T>().Where(critiria).Skip(skip).Take(take).ToListAsync();
        }


        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T ,bool>> critiria  ,int? skip, int? take , 
            Expression<Func<T, object>> orderBy = null , string orderbydirection = OrderBy.Assending )
        {
            IQueryable<T> querie = _context.Set<T>().Where(critiria);
            if (skip.HasValue)
                querie = querie.Skip(skip.Value); 
            
            if (take.HasValue) querie = querie.Take(take.Value);        

            if (orderBy != null)
            {
                if (orderbydirection == OrderBy.Assending)
                    querie = querie.OrderBy(orderBy);
                else 
                    querie.OrderByDescending(orderBy);      
            }

            return await  querie.ToListAsync();        

        }
        public async Task<IEnumerable<TResult>> CallingView<TResult>( int? skip, int? take ) where TResult : class
        {
           
            IQueryable<TResult> querue = _context.Set<TResult>();       

            if(skip.HasValue) querue = querue.Skip(skip.Value); 
            if(take.HasValue) querue = querue.Take(take.Value);

            return await querue.ToListAsync(); 


        }

       
       public async  Task<IEnumerable<TResult>> CallingView<TResult>(Expression<Func<TResult , bool>> critiria, int? skip, int? take) where TResult : class
        {

            IQueryable<TResult> querue = _context.Set<TResult>().Where(critiria);

            if (skip.HasValue) querue = querue.Skip(skip.Value);
            if (take.HasValue) querue = querue.Take(take.Value);

            return await querue.ToListAsync();
        }

       

    }
}
