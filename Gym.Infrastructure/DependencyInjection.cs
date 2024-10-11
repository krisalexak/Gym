using Gym.Application.Common.Interfaces;
using Gym.Infrastructure.Common.Persistence;
using Gym.Infrastructure.Subscriptions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) {

            services.AddDbContext<GymDbContext>(options => 
                options.UseSqlite("Data Source = GymManagement.db"));

            services.AddScoped<ISubscriptionRepository, SubscriptionsRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<GymDbContext>());

            return services;
        }
    }
}
