using System.Reflection;
using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.Mappers;
using BusinessAccessLayer.Interface;
using BusinessAccessLayer.Services;
using Common.Constants;
using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using DataAccessLayer.Repositories;
using Entities.DTOs;
using Entities.Mappings;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationConfiguration
{
    public static void ConnectDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(config.GetConnectionString(SystemConstants.CONNECTION_STRING_NAME)!);
        });
    }

    public static void RegisterRepository(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddHttpClient("customClient", client =>
        {
        }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        });

        IEnumerable<Type> implementationTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseService<>)));

        foreach (Type implementationType in implementationTypes)
        {
            Type[] implementedInterfaces = implementationType.GetInterfaces();
            foreach (Type implementedInterface in implementedInterfaces)
            {
                if (implementedInterface.IsGenericType)
                {
                    Type openGenericInterface = implementedInterface.GetGenericTypeDefinition();
                    if (openGenericInterface == typeof(IBaseService<>))
                    {
                        services.AddScoped(implementedInterface, implementationType);
                    }
                }
            }
        }

        services.Scan(scan =>
        {
            scan.FromAssembliesOf(typeof(IBaseService<>))
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });

        services.AddScoped<IMailService, MailService>();
        services.AddScoped<ICommonService, CommonService>();
        services.AddScoped<IUserService, UserService>();

        services.AddHttpContextAccessor();
    }

    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(SystemConstants.CORS_POLICY,
                builder => builder.WithOrigins(SystemConstants.CORS_ALLOWED_ORIGIN)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );
        });
    }

    public static void SetRequestBodySize(this IServiceCollection services)
    {
        services.Configure<IISServerOptions>(options =>
        {
            options.MaxRequestBodySize = int.MaxValue;
        });
    }

    public static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { cfg.AddExpressionMapping(); }, typeof(MappingProfile).Assembly);
    }

    public static IMapperConfigurationExpression AddExpressionMapping(this IMapperConfigurationExpression config)
    {
        config.Internal().Mappers.Insert(0, new ExpressionMapper());
        return config;
    }

    public static void RegisterMail(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<MailSettingsDTO>(config.GetSection("MailSettings"));
        services.AddScoped<IMailService, MailService>();
    }
}
