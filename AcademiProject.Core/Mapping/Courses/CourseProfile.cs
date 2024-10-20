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
        public CourseProfile()
        {
            GetStudentListMapping();
            GetCourseByIdMapping();
            AddCourseMapping();
            EditCourseMapping();
        }
    }
}
