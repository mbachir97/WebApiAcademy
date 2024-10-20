using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPaternWithUOW.EF.Data
{
    public class CourseConfiguratuion : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            //builder.HasKey(x => x.ud);
            //builder.Property(x => x.ud).ValueGeneratedOnAdd();
            builder.Property(x => x.CourseName).HasColumnType("Varchar").HasMaxLength(128).IsRequired();

            builder.Property(x => x.Price).HasPrecision(15, 2);
            builder.ToTable("Courses");


            //builder.HasData(SeedData.LodCourses()); 



        }


    }
}
