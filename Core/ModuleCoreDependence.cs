using AutoMapper;
using Core.Features.Students.Queries.Handlers;
using Core.Features.Departments.Queries.Handlers;
using Core.Features.Subjects.Queries.Handlers;
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
            
            // Students Handlers
            services.AddTransient<GetAllStudentCommandHandler>();
            services.AddTransient<CreateStudentCommandHandler>();
            services.AddTransient<UpdateStudentCommandHandler>();
            services.AddTransient<DeleteStudentCommandHandler>();
            services.AddTransient<GetStudentByIdCommandHandler>();
            
            // Departments Handlers
            services.AddTransient<GetAllDepartmentCommandHandler>();
            services.AddTransient<CreateDepartmentCommandHandler>();
            services.AddTransient<UpdateDepartmentCommandHandler>();
            services.AddTransient<DeleteDepartmentCommandHandler>();
            services.AddTransient<GetDepartmentByIdCommandHandler>();
            
            // Subjects Handlers
            services.AddTransient<GetAllSubjectsCommandHandler>();
            services.AddTransient<CreateSubjectCommandHandler>();
            services.AddTransient<UpdateSubjectCommandHandler>();
            services.AddTransient<DeleteSubjectCommandHandler>();
            services.AddTransient<GetSubjectByIdCommandHandler>();
            
            services.AddMediatR(cfg =>  cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
