using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore; // Add this for using SQLite
using MyRestApi.Infrastructure;
using MyRestApi.Features.UserAccounts.Data;
using MyRestApi.Features.UserAccounts.Services;

namespace MyRestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // ADD SERVICES TO CONTAINER
        public void ConfigureServices(IServiceCollection services)
        {
            // TEMPORARY FLAG FOR SWITCHING BETWEEN DATABASES
            var useSqlite = true; 

            if (useSqlite)
            {
                // USE SQLITE DATABASE
                var sqliteConnectionString = Configuration.GetConnectionString("SQLiteConnection");
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlite(sqliteConnectionString));
            }
            else
            {
                // USE MYSQL DATABASE
                var mysqlConnectionString = Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(mysqlConnectionString, ServerVersion.AutoDetect(mysqlConnectionString)));
            }

            services.AddControllers();

            // REGISTER SERVICES AND REPOSITORIES
            services.AddScoped<IUserRepository, UserRepository>();
            // services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPasswordService, PasswordService>();  // Register IPasswordService


            // ADD SWAGGER
            services.AddSwaggerGen();
        }

        // CONFIGURE HTTP REQUEST PIPELINE
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // USE DEVELOPER EXCEPTION PAGE
                app.UseDeveloperExceptionPage();
            }

            // USE HTTPS REDIRECTION
            app.UseHttpsRedirection();
            // USE ROUTING
            app.UseRouting();
            // USE AUTHORIZATION
            app.UseAuthorization();

            // USE SWAGGER
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // CONFIGURE SWAGGER UI
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            // USE ENDPOINTS
            app.UseEndpoints(endpoints =>
            {
                // MAP CONTROLLERS
                endpoints.MapControllers();
            });
        }
    }
}
