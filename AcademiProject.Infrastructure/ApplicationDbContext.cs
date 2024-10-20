using Microsoft.EntityFrameworkCore;
using RepositoryPaternWithUOW.Core.Model;
namespace RepositoryPaternWithUOW.EF

{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Instructor> instructors {  get; set; } 
        public DbSet<Office> Offices {  get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
                .HaveConversion<RepositoryPaternWithUOW.EF.Data.DateOnlyConverter>()
                .HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.ApplyConfiguration(new CourseConfiguration()); // not best practice

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
