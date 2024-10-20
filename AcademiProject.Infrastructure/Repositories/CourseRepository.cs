using Microsoft.EntityFrameworkCore;
using RepositoryPaternWithUOW.Core.Interfaces;
using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPaternWithUOW.EF.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        //private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<int> GetParticipantByCourse(string name)
        {

            //IQueryable<CourseOverview> sd = _context.Set<CourseOverview>(); 
            base._context.Set<CourseOverview>().ToList();


            return await _context.Set<CourseOverview>().
               Where(x => x.CourseName.ToLower().Contains(name.ToLower()))
               .SumAsync(x => x.NumberOfEnrolledParticipants);

            //return await base._context.Set<Course>().
            //    Where(x => x.CourseName.ToLower().Contains(name.ToLower())).SelectMany(x =>x.Sections)
            //    .SelectMany(x =>x.Participants).CountAsync();   

        }
    }
}
