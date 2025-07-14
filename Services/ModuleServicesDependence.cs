using Microsoft.Extensions.DependencyInjection;
using Services.Contracts;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ModuleServicesDependence
    {
        public static IServiceCollection AddServicesDependence(this IServiceCollection services)
        {
            services.AddTransient<IStudentServices, StudentServices>();
            services.AddTransient<ISubjectServices, SubjectServices>();
            services.AddTransient<IDepartmentServices, DepartmentServices>();
            return services;
        }
    }
}
