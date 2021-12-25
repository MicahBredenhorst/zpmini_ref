using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ZPMini.API;
using ZPMini.Data;
using ZPMini.Factory.Factory;
using ZPMini.Factory.Interface;
using ZPMini.Logic;
using ZPMini.Logic.Interface;

namespace ZPMini
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DefaultContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddAutoMapper(typeof(AutomapperConfiguration));
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZPMini", Version = "v1" });
            });

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Mock")
            {
                services.AddTransient<IRepositoryFactory, MockRepositoryFactory>();
            }
            else
            {
                services.AddTransient<IRepositoryFactory, RepositoryFactory>();
            }

            services.AddTransient<IPatientLogic, PatientLogic>();
            services.AddTransient<IFacilityLogic, FacilityLogic>();
            services.AddTransient<IInformationOwnershipLogic, InformationOwnershipLogic>();
            services.AddTransient<IPatientInformationLogic, PatientInformationLogic>();
            services.AddTransient<ITransferLogic, TransferLogic>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "Mock")
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => 
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "ZPMini v1");
                    options.RoutePrefix = "swagger";
                });
            }

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<DefaultContext>();
                dbContext.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
