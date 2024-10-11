﻿using Gym.Application.Common.Interfaces;
using Gym.Domain.Subscriptions;
using Gym.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Infrastructure.Subscriptions.Persistence
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s=>s.Id).ValueGeneratedNever();

            builder.Property("_adminId").HasColumnName("AdminId");

            builder.Property(s => s.SubscriptionType)
                .HasConversion(
                subscriptionType => subscriptionType.Value,
                value => SubscriptionType.FromValue(value));
        }
    }
}
