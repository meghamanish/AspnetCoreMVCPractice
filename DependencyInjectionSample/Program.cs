using DependencyInjectionSample.Classes;
using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Services;

namespace DependencyInjectionSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			builder.Services.AddTransient<IOperationTransient, OperationTransient>();
			builder.Services.AddScoped<IOperationScoped, OperationScoped>();
			builder.Services.AddSingleton<IOperationSingleton, OperationSingleton>();
			builder.Services.AddSingleton<IOperationSingletonInstance>(new OperationSingletonInstance(Guid.NewGuid()));
			builder.Services.AddScoped<OperationService>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
