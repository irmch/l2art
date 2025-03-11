using L2Art.Application.PrivateShops.Query;
using L2Art.Domain.Abstractions;
using L2Art.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
            services.AddScoped<PrivateShopTradingService>();
            services.AddScoped<MarkInactiveItemsService>();
            services.AddScoped<IPrivateShopItemTradingService, PrivateShopTradingService>();
            return services;
        }
    }
}
