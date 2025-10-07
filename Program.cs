using WebApplication1.Filters;
using WebApplication1.Middlewares;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
