using ASPNETCore.Context;
using ASPNETCore.Handlers;
using ASPNETCore.Middleware;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Repositories.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;   

namespace ASPNETCore
{
    public class Startup
    {
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

            //CORS
            services.AddCors(options =>
            {
                //options.AddDefaultPolicy(
                //    builder => builder.WithOrigins("http://localhost:5004 , http://localhost:5101")
                //        .AllowAnyHeader()
                //        .AllowAnyMethod());
                options.AddPolicy("mypolicy", builder =>
                    builder.WithOrigins("https://www.test-cors.org", "https://localhost:44340")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            }
                
            );

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API"
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
            services.AddScoped<SimpleAuthentication>();
            services.AddScoped<AccountRepository>();

            services.AddTokenAuthentication(Configuration);



            //services.AddApplicationInsightsTelemetry(Configuration);
            //services.AddMvc();
            //services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GeneralRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //CORS middleware
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); ;
            });
        }
    }
}
