using System.Reflection;
using System.Text;
using API.ExtAuthorization;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
        services.AddScoped<IJwtManagerService, JwtManagerService>();

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

    public static void ConfigAuthentication(this IServiceCollection services, IConfiguration config)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Description = "Bearer Authentication with JWT Token",
                Type = SecuritySchemeType.Http
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                            }
                        },
                    new List < string > ()
                    }
            });
        });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = config["Jwt:Issuer"],
                ValidAudience = config["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
            };
        });

        services.AddScoped<ExtAuthorizeFilter>();


        // Register the ExtAuthorizeHandler before adding policies
        services.AddScoped<IAuthorizationHandler, ExtAuthorizeHandler>();

        services.AddAuthorization(config =>
        {
            config.AddPolicy(SystemConstants.PRINCIPAL_POLICY, policy =>
            {
                policy.Requirements.Add(new ExtAuthorizeRequirement(SystemConstants.PRINCIPAL_POLICY));
            });
            config.AddPolicy(SystemConstants.TEACHER_POLICY, policy =>
            {
                policy.Requirements.Add(new ExtAuthorizeRequirement(SystemConstants.TEACHER_POLICY));
            });
            config.AddPolicy(SystemConstants.STUDENT_POLICY, policy =>
            {
                policy.Requirements.Add(new ExtAuthorizeRequirement(SystemConstants.STUDENT_POLICY));
            });
            config.AddPolicy(SystemConstants.LAB_INSTRUCTOR_POLICY, policy =>
            {
                policy.Requirements.Add(new ExtAuthorizeRequirement(SystemConstants.LAB_INSTRUCTOR_POLICY));
            });
            config.AddPolicy(SystemConstants.TEACHER_PRINCIPAL_POLICY, policy =>
            {
                policy.Requirements.Add(new ExtAuthorizeRequirement(SystemConstants.TEACHER_PRINCIPAL_POLICY));
            });
            config.AddPolicy(SystemConstants.ALL_USER_POLICY, policy =>
            {
                policy.Requirements.Add(new ExtAuthorizeRequirement(SystemConstants.ALL_USER_POLICY));
            });
        });
    }
}
