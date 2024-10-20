using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPaternWithUOW.Core.Model;
using RepositoryPaternWithUOW.Core.Model.Enum;

namespace RepositoryPaternWithUOW.EF.Data
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            // builder.Property(x => x.CourseName).HasMaxLength(255); // nvarchar(255)

          

            //The Old One
            //builder.Property(x => x.Title)
            //    .HasColumnType("VARCHAR")
            //    .HasMaxLength(50).IsRequired();

            builder.Property(x => x.ScheduleType)
              .HasConversion(
                   x => x.ToString(),
                   x => (ScheduleType)Enum.Parse(typeof(ScheduleType), x)
              );


            builder.ToTable("Schedules");


            builder.HasData(SeedData.LoadSchedules());
        }

      
    }
}
