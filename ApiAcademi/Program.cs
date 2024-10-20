
using AcademiProject.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryPaternWithUOW.Core.Interfaces;
using RepositoryPaternWithUOW.EF;
using RepositoryPaternWithUOW.EF.Repositories;
using AcademiProject.Service;
using AcademiProject.Core;
using AcademiProject.Core.MiddleWare;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
  builder.Services.AddDbContext<ApplicationDbContext>(options => 
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
 ,
  b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))) ;

builder.Services.AddInfraStructureDependencies()
    .AddModuleServiceDependencies().AddModuleCoreDependencies();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>(); 
app.UseHttpsRedirection();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();