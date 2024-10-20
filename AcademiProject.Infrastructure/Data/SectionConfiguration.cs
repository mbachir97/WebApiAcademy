using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPaternWithUOW.Core.Model;

namespace RepositoryPaternWithUOW.EF.Data
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {


            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            // builder.Property(x => x.CourseName).HasMaxLength(255); // nvarchar(255)

            builder.Property(x => x.SectionName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired();

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.CourseId)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Instructor)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.InstructorId)
                .IsRequired(false);
            builder.ToTable("Sections");



            //The old One
            //builder.HasMany(c => c.Schedules)
            //  .WithMany(x => x.Sections)
            //  .UsingEntity<SectionSchedule>(
            //    lh => lh.HasOne(x => x.Schedule).WithMany(x => x.SectionSchedules).HasForeignKey(x => x.ScheduleId),
            //    rh => rh.HasOne(x => x.Section).WithMany(x => x.SectionSchedules).HasForeignKey(x => x.SectionId)
            //    );
            builder.HasMany(x => x.Participants).WithMany(x => x.Sections).UsingEntity<Enrollment>();

            builder.HasOne(w => w.Schedule).WithMany(x => x.Sections).HasForeignKey(x => x.ScheduleId);
            builder.OwnsOne(x => x.TimeSlot, ts =>
            {
                ts.Property(p => p.StartTime).HasColumnType("time(0)").HasColumnName("StartTime").IsRequired();
                ts.Property(p => p.EndTime).HasColumnType("time(0)").HasColumnName("EndTime").IsRequired();
            });
            builder.OwnsOne(x => x.DateRange, ts =>
            {
                ts.Property(p => p.StartDate).HasColumnType("date").HasColumnName("StartDate").IsRequired();
                ts.Property(p => p.EndDate).HasColumnType("date").HasColumnName("EndDate").IsRequired();
            });
        }

        private static List<Section> LoadSections()
        {
            return new List<Section>
            {
                new Section { Id = 1, SectionName = "S_MA1", CourseId = 1, InstructorId = 1},
                new Section { Id = 2, SectionName = "S_MA2", CourseId = 1, InstructorId = 2},
                new Section { Id = 3, SectionName = "S_PH1", CourseId = 2, InstructorId = 1},
                new Section { Id = 4, SectionName = "S_PH2", CourseId = 2, InstructorId = 3},
                new Section { Id = 5, SectionName = "S_CH1", CourseId = 3, InstructorId =2},
                new Section { Id = 6, SectionName = "S_CH2", CourseId = 3, InstructorId = 3},
                new Section { Id = 7, SectionName = "S_BI1", CourseId = 4, InstructorId = 4},
                new Section { Id = 8, SectionName = "S_BI2", CourseId = 4, InstructorId = 5},
                new Section { Id = 9, SectionName = "S_CS1", CourseId = 5, InstructorId = 4},
                new Section { Id = 10, SectionName = "S_CS2", CourseId = 5, InstructorId = 5},
                new Section { Id = 11, SectionName = "S_CS3", CourseId = 5, InstructorId = 4}
            };
        }
    }
}
