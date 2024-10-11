using Gym.Application.Common.Interfaces;
using Gym.Domain.Subscriptions;
using Gym.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Infrastructure.Subscriptions.Persistence
{
    public class SubscriptionsRepository : ISubscriptionRepository
    {
        private readonly GymDbContext _dbContext;
        public SubscriptionsRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddSubscriptionAsync(Subscription subscription)
        {
            await _dbContext.Subscriptions.AddAsync(subscription);
        }
                                           
        public async Task<Subscription> GetByIdAsync(Guid Id)
        {
            return await _dbContext.Subscriptions.FindAsync(Id);
        }
    }
}
