using Microsoft.Extensions.DependencyInjection;
using SupplyScopeMVC.Application.Interfaces;
using SupplyScopeMVC.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IRecipientService, RecipientService>();
            services.AddTransient<IProductServices, ProductServices>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
