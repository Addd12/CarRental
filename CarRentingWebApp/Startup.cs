using System;
using AutoMapper;
using CarRentingWebApp.Models;
using CarRentingWebApp.Repository;
using CarRentingWebApp.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRentingWebApp
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
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMvc();
            Action<GlobalVariables> Global = (opt =>
            {
                opt.IsLoggedIn = false;
                opt.IsAdmin = false;
            });
            services.Configure(Global);
            //Fetching Connection string from APPSETTINGS.JSON  
            var ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");

            //Entity Framework  
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));


            var config = new MapperConfiguration(cfg =>
            {
                //User
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
            });

            services.AddSession(options =>
            {
                options.Cookie.Name = ".CarRental.Session";
                options.Cookie.IsEssential = true;
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // This method gets called by the runtime. Use this method to add services to the container.
            services.AddScoped<IDataRepository<User>, DataRepository<User>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}")
                    .MapRoute(
                    name: "login",
                    template: "{controller=Users}/{action=Login}/{id?}");
            });
        }
    }
}
