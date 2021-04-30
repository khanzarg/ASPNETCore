using ASPNETCore.Context;
using ASPNETCore.Handlers;
using ASPNETCore.Middleware;
using ASPNETCore.Repositories.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

            services.AddTokenAuthentication(Configuration);



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

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
