using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication1.context;
using WebApplication1.Controllers;
using WebApplication1.Filters;
using WebApplication1.IRepo;
using WebApplication1.Middlewares;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Framework service : Already Declared,Already Registerd
            //Built in service:  Already Declared,Need to Register
            // Add services to the container.
            //builder.Services.AddControllersWithViews();
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<GlobalExceptionHandleFilter>();
            });

            builder.Services.AddSession(options=>
            {
                options.IdleTimeout= TimeSpan.FromMinutes(30);
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CompanyContext>();
            //Custom sevice 
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();

            builder.Services.AddDbContext<CompanyContext>(options=>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            var app = builder.Build();

            // app.UseMiddleware<Middlewares.GlobalExceptionHandleMiddleware>();
            //app.UseMiddleware<LoggingMW>();

            #region Built in MW
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession(); // Session Middleware

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            #endregion

            #region Custom MW
            //app.Use(async (HttpContext, Next) =>
            //{
            //   await HttpContext.Response.WriteAsync("From Middleware 1\n");
            //    await Next.Invoke();
            //    await HttpContext.Response.WriteAsync("From Middleware 1----\n");
            //});
            //app.Use(async (HttpContext, Next) =>
            //{
            //    await HttpContext.Response.WriteAsync("From Middleware 2\n");
            //    await Next.Invoke();
            //    await HttpContext.Response.WriteAsync("From Middleware 2----\n");
            //});
            //app.Run(async (HttpContext) =>
            //{
            //    await HttpContext.Response.WriteAsync("From Middleware 3 Terminate\n");
            //});
            #endregion

            app.Run();
        }
    }
}
