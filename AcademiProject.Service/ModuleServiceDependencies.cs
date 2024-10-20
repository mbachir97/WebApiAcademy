using AcademiProject.Service.Abstraction;
using AcademiProject.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;
using RepositoryPaternWithUOW.Core.Interfaces;
using RepositoryPaternWithUOW.EF.Repositories;

namespace AcademiProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddModuleServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICourseService, CourseServise>();

            return services;
        }
    }
}
