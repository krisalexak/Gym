using Gym.Application.Common.Interfaces;
using Gym.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Infrastructure.Common.Persistence
{
    public  class GymDbContext :DbContext, IUnitOfWork
    {
        public GymDbContext() { }
        public GymDbContext(DbContextOptions<GymDbContext> options) :base(options) 
        {
        
        }
        public DbSet<Subscription> Subscriptions { get; set; }
        public async Task CommitChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
