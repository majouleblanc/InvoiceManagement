using InvoiceManagement.Application.Interfaces;
using InvoiceManagement.Domain.Entities;
using InvoiceManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(o=>o.UseSqlServer(configuration["ConnectionStrings:SqlConnectionString"]));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                //the user name should be unique
                option.User.RequireUniqueEmail = true;
                //configuration for password
                option.Password.RequireDigit = true;        //must have numbers
                option.Password.RequireLowercase = true;    //must have a lower case
                option.Password.RequiredLength = 5;         //length must be 5 or more
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()     
                .AddDefaultTokenProviders();


            //we add authentication to the api with some configuration
            services.AddAuthentication(auth =>
            {
                //here we tell asp net core which scheme we wil be using, in our case its json web token or jwt
                //jwt is the beste way to secure an api and it's statless behavior makes his almost the only way to secure an api that respects REST principles
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>      //we add jwt to the auth middelware
            {
                //here we configure how the token should be validate when received of generate a token
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,

                    //i have set those parametre in the appSettings.json
                    ValidAudience = configuration["AuthSettings:Audience"],
                    ValidIssuer = configuration["AuthSettings:Issuer"],
                    RequireExpirationTime = true,
                    //IssuerSigningKey is the key that we gonna use to encrypte the token
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"])),
                    ValidateIssuerSigningKey = true
                };
            });

            // here we add the role based authorization to the DI container
            services.AddAuthorization(o =>
            {
                o.AddPolicy("USER", policy => policy.RequireRole("USER"));
                o.AddPolicy("ADMIN", policy => policy.RequireRole("ADMIN"));
            });

            return services;
        }
    }
}
