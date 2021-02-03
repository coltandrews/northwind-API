using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using northwindAPI.BusinessLogic;

namespace northwindAPI
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

            // Add CORS support
            // This policy named AllowAll must be specified in the .UseCors method below
            services.AddCors(o => o.AddPolicy("AllowAll",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }));

            // dependency injection

            // we create one database properties instance with values from the
            // appsettings.json config files
            services.AddSingleton(db =>
            {
                return new DatabaseProperties()
                {
                    DataSource = Configuration.GetValue<string>("Database:Datasource"),
                    UserID = Configuration.GetValue<string>("Database:Userid"),
                    Password = Configuration.GetValue<string>("Database:Password"),
                    InitialCatalog = Configuration.GetValue<string>("Database:InitialCatalog")
                };
            });

            // SQL access repositories for CRUD operations
            services.AddScoped<IEmployeesRepo, EmployeesRepo>();
            services.AddScoped<ICustomersRepo, CustomersRepo>();

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
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
