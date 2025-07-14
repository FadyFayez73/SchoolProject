using AutoMapper;
using Core.Features.Students.Queries.Handlers;
using Core.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ModuleCoreDependence
    {
        public static IServiceCollection AddCoreDependence(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<GetAllStudentHandler>();
            services.AddMediatR(cfg =>  cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
