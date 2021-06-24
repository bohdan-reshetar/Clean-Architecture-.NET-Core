using AutoMapper;
using CleanArchitecture.Application.AutoMapper.Profiles;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.CommandHandlers;
using CleanArchitecture.Domain.Commands;
using CleanArchitecture.Domain.Core.Bus;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Bus;
using CleanArchitecture.Infrastructure.Data.Context;
using CleanArchitecture.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.IoC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToViewModelProfile),
                typeof(ViewModelToDomainProfile));
            //AutoMapperConfiguration.RegisterMappings();
        }

        public static void AddUniversityDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UniversityDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Application Layer
            services.AddScoped<ICourseService, CourseService>();
        }

        public static void AddDataServices(this IServiceCollection services)
        {
            // Domain InMemoryBus MediatR
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Domain Handlers
            services.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();

            //Infrastructure.Data Layer
            services.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}