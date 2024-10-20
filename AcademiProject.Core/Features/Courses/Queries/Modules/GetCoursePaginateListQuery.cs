using AcademiProject.Core.Features.Courses.Queries.Result;
using AcademiProject.Core.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiProject.Core.Features.Courses.Queries.Modules
{
    public  class GetCoursePaginateListQuery : IRequest<PaginateResult<GetCoursePaginateListResponse>>
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } 
        
        public string Search {  get; set; } 
    }
}
