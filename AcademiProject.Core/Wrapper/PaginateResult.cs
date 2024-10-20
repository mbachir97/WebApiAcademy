using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiProject.Core.Wrapper
{
    public  class PaginateResult<T>
    {
        public List<T> Data { get; set; }
        public int CurrentPage { get; set; } 
       public  int TotalPages {  get; set; }   
        
        public int TotalCount { get; set; }     

        public object Meta {  get; set; }   

        public int PageSize { get; set; }

        public bool HasPrevousePage => CurrentPage > 1; 
        public bool HasNextPage => CurrentPage < TotalPages;

        public List<string> messages { get; set; } = new();

        public bool Succeeded { get; set; } 

        private PaginateResult(int currentPage , int totalCount
           , int pageSize,  bool succeeded , List<T> data = default)
        {
            Data = data;
            CurrentPage = currentPage;
            TotalPages = (int) Math.Ceiling((totalCount / (double)pageSize));
            TotalCount = totalCount;

            PageSize = pageSize;
          
            Succeeded = succeeded;
        }

        public static PaginateResult<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new(page, count, pageSize, true, data);
        }
    }
}
