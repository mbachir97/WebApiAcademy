using AcademiProject.Core.Features.Courses.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademiProject.Core.Basic;
namespace AcademiProject.Core.Features.Courses.Queries.Modules
{
    public  class GetCourseByIdQuery : IRequest<Response<GetSingleCourseResponse>>   
    {
      public int Id { get; set; }       
    }
}
