using AcademiProject.Core.Features.Courses.Commands.Modules;
using AcademiProject.Core.Features.Courses.Queries.Result;
using AutoMapper;
using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiProject.Core.Mapping.Courses
{
    public partial class CourseProfile : Profile
    {
        public void AddCourseMapping()
        {
            CreateMap<AddCourseCommand, Course>();
            
        }
    }
}
