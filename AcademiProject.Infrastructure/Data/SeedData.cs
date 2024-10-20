using Azure;
using RepositoryPaternWithUOW.Core.Model;
using RepositoryPaternWithUOW.Core.Model.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RepositoryPaternWithUOW.EF.Data
{
    public static class SeedData
    {
        public static List<Instructor> LoadInstructors()
        {
            return new List<Instructor>()
            {
                 new Instructor { Id = 1, FName = "Ahmed", LName = "Abdullah", OfficeId = 1},
                new Instructor { Id = 2, FName = "Yasmeen", LName = "Yasmeen", OfficeId = 2},
                new Instructor { Id = 3, FName = "Khalid", LName = "Hassan", OfficeId = 3},
                new Instructor { Id = 4, FName = "Nadia", LName = "Ali", OfficeId = 4},
                new Instructor { Id = 5, FName = "Ahmed", LName = "Abdullah", OfficeId = 5},
            };
        }

        public static List<Office> LoadOffices()
        {
            return new List<Office>
            {

                    new Office { Id = 1, OfficeName = "Off_05", OfficeLocation = "building A"},
                    new Office { Id = 2, OfficeName = "Off_12", OfficeLocation = "building B"},
                    new Office { Id = 3, OfficeName = "Off_32", OfficeLocation = "Adminstration"},
                    new Office { Id = 4, OfficeName = "Off_44", OfficeLocation = "IT Department"},
                    new Office { Id = 5, OfficeName = "Off_43", OfficeLocation = "IT Department"}
            };
        }

        //private static List<SectionSchedule> LoadSectionSchedules()
        //{
        //    return new List<SectionSchedule>
        //    {
        //        new SectionSchedule { Id = 1, SectionId = 1, ScheduleId = 1, StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("10:00:00") },
        //        new SectionSchedule { Id = 2, SectionId = 2, ScheduleId = 3, StartTime = TimeSpan.Parse("14:00:00"), EndTime = TimeSpan.Parse("18:00:00") },
        //        new SectionSchedule { Id = 3, SectionId = 3, ScheduleId = 4, StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("15:00:00") },
        //        new SectionSchedule { Id = 4, SectionId = 4, ScheduleId = 1, StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("12:00:00") },
        //        new SectionSchedule { Id = 5, SectionId = 5, ScheduleId = 1, StartTime = TimeSpan.Parse("16:00:00"), EndTime = TimeSpan.Parse("18:00:00") },
        //        new SectionSchedule { Id = 6, SectionId = 6, ScheduleId = 2, StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("10:00:00") },
        //        new SectionSchedule { Id = 7, SectionId = 7, ScheduleId = 3, StartTime = TimeSpan.Parse("11:00:00"), EndTime = TimeSpan.Parse("14:00:00") },
        //        new SectionSchedule { Id = 8, SectionId = 8, ScheduleId = 4, StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("14:00:00") },
        //        new SectionSchedule { Id = 9, SectionId = 9, ScheduleId = 4, StartTime = TimeSpan.Parse("16:00:00"), EndTime = TimeSpan.Parse("18:00:00") },
        //        new SectionSchedule { Id = 10, SectionId = 10, ScheduleId = 3, StartTime = TimeSpan.Parse("12:00:00"), EndTime = TimeSpan.Parse("15:00:00") },
        //        new SectionSchedule { Id = 11, SectionId = 11, ScheduleId = 5, StartTime = TimeSpan.Parse("09:00:00"), EndTime = TimeSpan.Parse("11:00:00") }
        //    };
        //}

        //private static List<Section> LoadSections()
        //{
        //    return new List<Section>
        //    {
        //        new Section { Id = 1, SectionName = "S_MA1", CourseId = 1, InstructorId = 1},
        //        new Section { Id = 2, SectionName = "S_MA2", CourseId = 1, InstructorId = 2},
        //        new Section { Id = 3, SectionName = "S_PH1", CourseId = 2, InstructorId = 1},
        //        new Section { Id = 4, SectionName = "S_PH2", CourseId = 2, InstructorId = 3},
        //        new Section { Id = 5, SectionName = "S_CH1", CourseId = 3, InstructorId =2},
        //        new Section { Id = 6, SectionName = "S_CH2", CourseId = 3, InstructorId = 3},
        //        new Section { Id = 7, SectionName = "S_BI1", CourseId = 4, InstructorId = 4},
        //        new Section { Id = 8, SectionName = "S_BI2", CourseId = 4, InstructorId = 5},
        //        new Section { Id = 9, SectionName = "S_CS1", CourseId = 5, InstructorId = 4},
        //        new Section { Id = 10, SectionName = "S_CS2", CourseId = 5, InstructorId = 5},
        //        new Section { Id = 11, SectionName = "S_CS3", CourseId = 5, InstructorId = 4}
        //    };

        //}

        public static List<Schedule> LoadSchedules()
        {
            return new List<Schedule>
            {
                new Schedule { Id = 1, ScheduleType = ScheduleType.Daily, SUN = true, MON = true, TUE = true, WED = true, THU = true, FRI = false, SAT = false },
                new Schedule { Id = 2, ScheduleType = ScheduleType.DayAfterDay, SUN = true, MON = false, TUE = true, WED = false, THU = true, FRI = false, SAT = false },
                new Schedule { Id = 3, ScheduleType = ScheduleType.TwiceAWeek, SUN = false, MON = true, TUE = false, WED = true, THU = false, FRI = false, SAT = false },
                new Schedule { Id = 4, ScheduleType = ScheduleType.Weekend, SUN = false, MON = false, TUE = false, WED = false, THU = false, FRI = true, SAT = true },
                new Schedule { Id = 5, ScheduleType = ScheduleType.Compact, SUN = true, MON = true, TUE = true, WED = true, THU = true, FRI = true, SAT = true }
            };
        }

        public static List<Course> LodCourses()
        {
            return new List<Course>
            {
                new Course { Id = 1, CourseName = "Flutter", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 2, CourseName = "CS50", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 4, CourseName = "Microsoft 365", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 5, CourseName = "data Scientist ", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 6, CourseName = "Network Security ", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 7, CourseName = "Artificial Intelligence", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 8, CourseName = "Machine Learning", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 9, CourseName = "Frontend Engineer(Angular)", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 10, CourseName = "Frontend Engineer(React)", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 11, CourseName = "Operating Systems", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 12, CourseName = ".NET Backend Engineer", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 13, CourseName = "Database Administrator", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 14, CourseName = "ASP.NET Full Stack Web Development", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 15, CourseName = "Object Oriented Design & Analysis", Price = 3669, HoursToComplete = 50 },
                new Course { Id = 3, CourseName = "tsql", Price = 3669, HoursToComplete = 50 },

            };


            }
        }
    }

