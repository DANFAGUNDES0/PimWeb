using AIssist.Application.Services;
using AIssist.Application.Services.Interfaces;
using AIssist.Domain.Interfaces;
using AIssist.Domain.Services;
using AIssist.Domain.Services.Interfaces;
using AIssist.Infrastructure.Data;
using AIssist.Infrastructure.Ioc.Configs.AutoMap;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AIssist.Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            AddApplicationServices(services);
            AddDomainServices(services);
            AddAutoMapperConfig(services);
        }

        private static void AddAutoMapperConfig(IServiceCollection services)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
                mc.AddProfile(new MappingUser());
                mc.AddProfile(new MappingRootCause());
                mc.AddProfile(new MappingLog());
                mc.AddProfile(new MappingTicket());
            }, loggerFactory);

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void AddApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IProfileAppService, ProfileAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IRootCauseAppService, RootCauseAppService>();
            services.AddScoped<IStatusAppService, StatusAppService>();
            services.AddScoped<ILogAppService, LogAppService>();
            services.AddScoped<ITicketAppService, TicketAppService>();
        }

        private static void AddDomainServices(IServiceCollection services)
        {
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRootCauseService, RootCauseService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IAppDbContext, AppDbContext>();
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            return services;
        }
    }
}

