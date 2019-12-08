using AutoMapper;
using Domain.Abstract;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Domain.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Helpers
{
    public static class InjectionModule
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(x => x.AddProfile(new AutoMapperProfile())).CreateMapper());
            services.AddTransient<IUserService, UserService>();
            return services;
        }

        public static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<User>, RepositoryBase<User>>();
            services.AddScoped<IBaseRepository<RefreshToken>, RepositoryBase<RefreshToken>>();
            return services;
        }
    }
}
