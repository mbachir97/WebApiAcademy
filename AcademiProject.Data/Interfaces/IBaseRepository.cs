using RepositoryPaternWithUOW.Core.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPaternWithUOW.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync(string[] Includes = null);

        T Find(Expression<Func<T, bool>> critiria);        
        Task<T> FindAsync(Expression<Func<T, bool>> critiria , string[] Includes = null);
      
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> critiria , string[] Includes = null);

        IQueryable<T> GetTableNoTracking();

        IQueryable<T> GetTableTracking();

        Task<T> AddAsync(T entity);

        Task AddRangeAsync(ICollection<T> entities);

        Task<T> UpdateAsync(T entiy);

        Task DeleteAsync(T entity);

        Task<IEnumerable<TResult>> CallingView<TResult>( int? skip, int? take) where TResult : class;
        Task<IEnumerable<TResult>> CallingView<TResult>(Expression<Func<TResult, bool>> critiria ,  int? skip, int? take) where TResult : class;

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> critiria,
             int? skip , int? take, Expression<Func<T, object>> orderBy = null, string orderbydirection = OrderBy.Assending);
    }
   
}
