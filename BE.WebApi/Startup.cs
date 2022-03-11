using BE.Dal;
using BE.Service;
using BE.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BE.WebApi.Filters;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;
using BE.WebApi.Extensions;
using BE.Service.ConfigurationOptions;

namespace BE.WebApi
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

            services.AddConfigurations(Configuration);

            var jsonWebTokenOptions = Configuration.GetSection(JsonWebTokenOptions.Section).Get<JsonWebTokenOptions>();
            var connectionString = Configuration.GetConnectionString("Default");

            services.AddDbContext<EntityDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            MigrateDatabase(connectionString);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BE API", Version = "v1" });
            });

            services.AddMvc(options =>
            {
                options.Filters.Add<HandleCommonExceptionFilter>();
            });
           
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder => builder
                        .WithOrigins(Configuration.GetValue<string>("CORSAllowedOrigins"))
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-TotalCount")
                        .AllowAnyMethod());
            });

            services.AddTransient<IAdPremiumService, AdPremiumService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<ISubcategoryTypeService, SubCategoryTypeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BE API V1");

            });

            app.UseRouting();

            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Ajeet: Migrate any database changes on startup (includes initial db creation)
        /// Not reqired in case when we have seperate db scripts that we are executing in backend.
        /// </summary>
        /// <param name="connectionString"></param>
        private static void MigrateDatabase(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EntityDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            using (var entityDbContext = new EntityDbContext(optionsBuilder.Options))
            {
                entityDbContext.Database.Migrate();
            }
        }
    }
}
