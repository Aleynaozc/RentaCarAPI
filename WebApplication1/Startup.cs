using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebApplication1.Data;
using WebApplication1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication1
{
    public class Startup
    {

        private readonly string MyPolicy = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(
                 options =>
                 {
                     options.DefaultAuthenticateScheme =
                     JwtBearerDefaults.AuthenticationScheme;
                     options.DefaultChallengeScheme =
                     JwtBearerDefaults.AuthenticationScheme;

                 }
                 ).AddJwtBearer(x =>
                 {
                     var key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                     x.Audience = "rentacar";
                     x.RequireHttpsMetadata = false;
                     x.SaveToken = true;
                     x.ClaimsIssuer = "Issuer";
                     x.TokenValidationParameters = new TokenValidationParameters
                     {
                         IssuerSigningKey = new SymmetricSecurityKey(key),
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         ValidateIssuer = false,
                         ValidateAudience = true
                     };
                     x.Events = new JwtBearerEvents()
                     {
                         OnTokenValidated = (context) =>
                         {
                             var name = context.Principal.Identity.Name;
                             if (string.IsNullOrEmpty(name))
                             {
                                 context.Fail("Unathorized. Please re-login.");
                             }
                             return Task.CompletedTask;
                         }
                     };
                 }
                 );

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Role", UserRole.ADMIN.ToString()));
                options.AddPolicy("UserPolicy", policy => policy.RequireClaim("Role", UserRole.USER.ToString()));
            });


            services.AddCors(o => o.AddPolicy(MyPolicy, builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();

            }));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RentaCarAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
            {
                 Description =
                 "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                 Name = "Authorization",
                 In = ParameterLocation.Header,
                 Type = SecuritySchemeType.ApiKey,
                 Scheme = "Bearer"
                 });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

            });

            services.AddDbContext<RentaCarContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RentaCarDatabase")));

        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(MyPolicy);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
