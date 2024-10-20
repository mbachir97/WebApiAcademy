using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPaternWithUOW.Core.Interfaces
{
    public  interface ICourseRepository : IBaseRepository<Course>
    {
        Task<int> GetParticipantByCourse(string name); 
    }
}
