using ASPNETCore.Context;
using ASPNETCore.Handlers;
using ASPNETCore.Middleware;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Repositories.Interface;
using ASPNETCore.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace ASPNETCore
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MyContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder =>
                    {
                        builder
                        .WithOrigins("https://www.test-cors.org", "https://localhost:44374")
                        .AllowAnyHeader().WithMethods("POST", "PUT", "GET");
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { 
                    Version = "v1.0",
                    Title = "ToDo API",
                    Description = "A simple example"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            });

            //services.Configure<EmailSettings>(Configuration.GetSection("MailSettings"));
            services.AddScoped<IGenericDapper, GeneralDapper>();

            services.AddScoped<AddressRepository>();
            services.AddScoped<ContactRepository>();
            services.AddScoped<DistrictRepository>();
            services.AddScoped<EducationRepository>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<EmployeeRoleRepository>();
            services.AddScoped<MajorRepository>();
            services.AddScoped<ProvinceRepository>();
            services.AddScoped<RoleRepository>();
            services.AddScoped<SubDistrictRepository>();
            services.AddScoped<TerritoryRepository>();
            services.AddScoped<UniversityRepository>();
            services.AddScoped<ParameterRepository>();
            services.AddScoped<LoginModelRepository>();
            services.AddScoped<SimpleAuthentication>();

            //services.AddTokenAuthentication(Configuration);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtAuth:ValidIssuer"],
                    ValidAudience = Configuration["JwtAuth:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtAuth:secret"]))
                };
            });

            //services.AddApplicationInsightsTelemetry(Configuration);
            //services.AddMvc();
            //services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GeneralRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Versioned API v1.0");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
