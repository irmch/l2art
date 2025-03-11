using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L2Art.Domain.PrivateShops;
using L2Art.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using L2Art.Domain.Abstractions;
using L2Art.Infrastructure.BGServices;
using L2Art.Domain.ItemNames;
using L2Art.Domain.Users;
using L2Art.Application.Abstractions;
using L2Art.Domain.Auctions;

namespace L2Art.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration));

            services.AddScoped<IPrivateShopsRepository, PrivateShopsRepository>();
            services.AddScoped<IItemNameRepository, ItemNameRepository>();
            services.AddScoped<IAuctionRepository, AuctionRepository>();

            //services.AddHostedService<MarkInactiveItemsBackgroundService>();
            //services.AddHostedService<MarkInactiveAuctionsBackgroundService>();
            //services.AddHostedService<PrivateShopsUpdateService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProvider, JwtProvider>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
