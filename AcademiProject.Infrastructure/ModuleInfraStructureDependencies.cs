using Microsoft.Extensions.DependencyInjection;
using RepositoryPaternWithUOW.Core.Interfaces;
using RepositoryPaternWithUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiProject.Infrastructure
{
    public static  class ModuleInfraStructureDependencies
    {
        public static IServiceCollection AddInfraStructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            
            return services;    
        }
    }
}
