using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiProject.Service.Abstraction
{
    public  interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id) ;
        Task<Course> AddAsync(Course course);
        Task<bool> IsCourseExistByName(string name);
        Task<bool> IsCourseExistByName(int id, string name);
        Task<Course> UpdateCourseAsync(Course course);

        IQueryable<Course> GetCourseQuerable();
        IQueryable<Course> GetFilterCourseQuerable(string search);

        Task<string> DeleteCourseAsync(Course course); 
    }
}
