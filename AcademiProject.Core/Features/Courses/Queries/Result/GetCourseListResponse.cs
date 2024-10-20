using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiProject.Core.Features.Courses.Queries.Result
{
    public  class GetCourseListResponse
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public decimal Price { get; set; }
        public int HoursToComplete { get; set; }

        public string[] Sections { get; set; }      
    }
}
