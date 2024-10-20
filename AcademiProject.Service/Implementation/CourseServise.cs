using AcademiProject.Service.Abstraction;
using Microsoft.EntityFrameworkCore;
using RepositoryPaternWithUOW.Core.Interfaces;
using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiProject.Service.Implementation
{
    public class CourseServise : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseServise(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync(new string[] { "Sections" });
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            var Student = await _courseRepository.GetTableNoTracking().
                Include(x => x.Sections).FirstOrDefaultAsync(x => x.Id == id);

            return Student;
        }

        public async Task<Course> AddAsync(Course course)
        {
            if (_courseRepository.GetTableNoTracking().Any(x => x.CourseName.ToLower() == course.CourseName.ToLower()))
            {
                return course;
            }

            return await _courseRepository.AddAsync(course);
        }

        public async Task<bool> IsCourseExistByName(string name)
        {
            return await _courseRepository.GetTableNoTracking()
                .AnyAsync(x => x.CourseName.ToLower() == name.ToLower());
        }

        public async Task<bool> IsCourseExistByName(int id, string name)
        {
            return await _courseRepository.
              GetTableNoTracking().AnyAsync(x => x.CourseName.ToLower() == name.ToLower() && x.Id != id);
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
             return   await  _courseRepository.UpdateAsync(course);  
        }

        public async Task<string> DeleteCourseAsync(Course course)
        {
            //try
            //{
            //   await  _courseRepository.DeleteAsync(course);
            //    return "succeees";
            //}
            //catch (Exception ex) 
            //{
            //    return "faild";
            //}

            await _courseRepository.DeleteAsync(course);
            return "succeees";
        }

        public  IQueryable<Course> GetCourseQuerable()
        {
          return  _courseRepository.GetTableNoTracking().Include(x =>x.Sections).AsQueryable();
        }

        public IQueryable<Course> GetFilterCourseQuerable(string search )
        {
            IQueryable<Course> querable  =  _courseRepository.GetTableNoTracking().
                Include(x => x.Sections).AsQueryable();
            if (string.IsNullOrEmpty(search)) return querable;
            
            return querable.Where(x =>x.CourseName.ToLower().Contains(search.ToLower()));
        }
    }
}
