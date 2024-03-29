using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupplyScopeMVC.Application;
using SupplyScopeMVC.Application.Interfaces;
using SupplyScopeMVC.Application.Services;
using SupplyScopeMVC.Application.ViewModels.Recipient;
using SupplyScopeMVC.Domain.Interfaces;
using SupplyScopeMVC.Infrastructure;
using SupplyScopeMVC.Infrastructure.Repositories;
using SupplyScopeMVC.Web.Models;

namespace SupplyScopeMVC.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddFile("Logs/myLog-{Date}.txt");


            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Context>();
            builder.Services.AddControllersWithViews();

            // flutentValidation
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddTransient<IValidator<NewRecipientVm>, NewRecipientValidaton>();

            // Identity 
            builder.Services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
            });

            // Authorization 
            builder.Services.AddAuthorization(options => {
                options.AddPolicy("CanEditClient", policy =>
                {
                    policy.RequireClaim("EditClient");
                    policy.RequireClaim("ShowClient");
                    policy.RequireRole("Admin");
                });
            });

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // **              ** //
            //app.MapControllerRoute(
            //name: "productSpecification",
            //pattern: "productSpecification/{*product}",
            //defaults: new { controller = "ProductSpecification", action = "Product" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.Run();
        }
    }
}
