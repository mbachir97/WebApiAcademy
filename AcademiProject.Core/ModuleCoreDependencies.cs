using AcademiProject.Service.Abstraction;
using AcademiProject.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;

using AcademiProject.Core.Features.Courses.Commands.Modules;
using AcademiProject.Core.Behavior;
using MediatR;

namespace AcademiProject.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddModuleCoreDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cg => cg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssemblyContaining<AddCourseCommand>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
