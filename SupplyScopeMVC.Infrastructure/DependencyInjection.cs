using Microsoft.Extensions.DependencyInjection;
using SupplyScopeMVC.Domain.Interfaces;
using SupplyScopeMVC.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IRecipientRepository, RecipientRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
