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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FName)
              .HasColumnType("VARCHAR")
              .HasMaxLength(50).IsRequired();

            builder.Property(x => x.LName)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50).IsRequired();


            builder.ToTable("Instructors");



            builder.HasOne(x => x.Office).WithOne(x => x.Instructor).
                HasForeignKey<Instructor>(x => x.OfficeId).IsRequired(false);

            builder.HasIndex(x => x.OfficeId).IsUnique()
                ;

            builder.HasData(SeedData.LoadInstructors()); 


        }

      
    }
}
