using AcademiProject.Core.Features.Courses.Queries.Result;
using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AcademiProject.Core.Mapping.Courses
{
    public partial class CourseProfile 
    {
        public void GetStudentListMapping()
        {

            CreateMap<Course, GetCourseListResponse>().
                ForMember(dest => dest.Sections, opt => opt.
                MapFrom(src => src.Sections.Select(x => x.SectionName).ToArray()));
        }
    }
}
