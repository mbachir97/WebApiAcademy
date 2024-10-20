using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPaternWithUOW.Core.Model
{
    public class Section : Entity
    {

        public string? SectionName { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public int? InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
        public int ScheduleId { get; set; }
        public Schedule? Schedule { get; set; }
    

        public TimeSlot TimeSlot { get; set; } = new();
        public DateRange DateRange { get; set; } = new();


      public ICollection<Participant> Participants { get; set; } = new List<Participant>();

    //    public ICollection<Enrollment> Enrolments { get; } = new List<Enrollment>();



    }
    public class TimeSlot
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public override string ToString()
        {
            return $"{StartTime.ToString("hh\\:mm")} - {EndTime.ToString("hh\\:mm")}";
        }
    }

    public class DateRange
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public override string ToString()
        {
            return $"{StartDate.ToString("yyyy-MM-dd")} - {EndDate.ToString("yyyy-MM-dd")}";
        }
    }
}
