using AcademiProject.Core.Features.Courses.Queries.Result;
using MediatR;
using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademiProject.Core.Basic;
namespace AcademiProject.Core.Features.Courses.Commands.Modules
{
    public  class AddCourseCommand : IRequest<Response<Course>>
    {
    
        public string? CourseName { get; set; }
        public decimal Price { get; set; }
        public int HoursToComplete { get; set; }

    }
}
