using AcademiProject.Core.Features.Courses.Queries.Result;
using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiProject.Core.Mapping.Courses
{
    public  partial class CourseProfile
    {
        public void GetCourseByIdMapping()
        {
            CreateMap<Course, GetSingleCourseResponse>().
               ForMember(dest => dest.Sections, opt => opt.
               MapFrom(src => src.Sections.Select(x => x.SectionName).ToArray()));
        }

    }
}
