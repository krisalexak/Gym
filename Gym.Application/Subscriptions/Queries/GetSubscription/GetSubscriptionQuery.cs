using ErrorOr;
using Gym.Domain.Subscriptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.Subscriptions.Queries
{
    public record GetSubscriptionQuery(Guid SubscriptionId) :IRequest<ErrorOr<Subscription>>;
}
