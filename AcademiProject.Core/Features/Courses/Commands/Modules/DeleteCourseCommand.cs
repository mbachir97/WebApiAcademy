using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademiProject.Core.Basic;
namespace AcademiProject.Core.Features.Courses.Commands.Modules
{
    public  class DeleteCourseCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }  
    }
}
