using Application.Services;
using Application.Services.Interface;
using AutoMapper;
using DataAccess.Repo;
using DataAccess.Repo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCuting.Config
{
    public static class ApiConfig
    {
        public static IServiceCollection ApiConfigServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUsuarioRepo, UsuarioRepo>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Maps.ApiMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
