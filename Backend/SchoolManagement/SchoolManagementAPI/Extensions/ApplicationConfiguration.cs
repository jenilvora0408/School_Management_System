using BusinessAccessLayer.Interface;
using BusinessAccessLayer.Profiles;
using BusinessAccessLayer.Services;
using Common.Constants;
using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using DataAccessLayer.Repositories;
using Entities.DTOs.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolManagementAPI.ExtAuthorization;
using System.Reflection;
using System.Text;

namespace SchoolManagementAPI.Extensions
{
    public static class ApplicationConfiguration
    {
        public static void ConnectDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString(SystemConstants.CONNECTION_STRING_NAME)!);
            });
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IAdmitRequestService, AdmitRequestService>();
            services.AddScoped<IAdmitRequestApprovalService, AdmitRequestApprovalService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IJwtManagerService, JwtManagerService>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(SystemConstants.CORS_POLICY,
                    builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true; // Enable detailed errors for debugging
            }).AddJsonProtocol(options =>
            {
                options.PayloadSerializerOptions.PropertyNamingPolicy = null; // Customize JSON serialization if needed
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
            services.AddAutoMapper(typeof(MappingProfile));
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
                config.AddPolicy(SystemConstants.ALL_USER_POLICY, policy =>
                {
                    policy.Requirements.Add(new ExtAuthorizeRequirement(SystemConstants.ALL_USER_POLICY));
                });
            });
        }
    }
}
