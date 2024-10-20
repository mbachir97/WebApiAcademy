using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPaternWithUOW.Core.Model
{
    public class Course 
    {
        public int Id {  get; set; }    
    
        public string? CourseName { get; set; }
        public decimal Price { get; set; }
        public int HoursToComplete { get; set; }
        public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
