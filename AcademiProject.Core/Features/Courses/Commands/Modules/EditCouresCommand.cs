using AcademiProject.Core.Basic;
using MediatR;
using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiProject.Core.Features.Courses.Commands.Modules
{
    public class EditCouresCommand : IRequest<Response<Course>>
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public decimal Price { get; set; }
        public int HoursToComplete { get; set; }
    }
}
