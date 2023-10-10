using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Vidly.Controllers;
using Vidly.Data;
using Vidly.Models;

namespace Vidly
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //For database connection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            ////custom route for movies by released date
            //app.MapControllerRoute(
            //        name: "MoviesByReleaseDate",
            //        pattern: "movies/released/{year}/{month}",
            //        defaults: new { controller = "Movies", action = "ByReleaseDate" },
            //         new {year = @"\d{4}",month = @"\d{2}"}
            //    );

            app.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Accounts}/{action=Login}/{id?}");
            

            app.Run();
        }
    }
}