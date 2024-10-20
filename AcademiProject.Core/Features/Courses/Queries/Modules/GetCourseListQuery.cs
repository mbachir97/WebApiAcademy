using AcademiProject.Core.Features.Courses.Queries.Result;
using MediatR;
using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademiProject.Core.Basic;


namespace AcademiProject.Core.Features.Courses.Queries.Modules
{
    public  class GetCourseListQuery : IRequest<Response<IEnumerable<GetCourseListResponse>>>
    {

    }
}
